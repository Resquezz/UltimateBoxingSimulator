using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Ultimate_Boxing_Simulator.Equipment;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Factory;
using Ultimate_Boxing_Simulator.Equipment.Concrete_Fabrics;
using Ultimate_Boxing_Simulator.Equipment.Concrete_Products;
using Ultimate_Boxing_Simulator.Equipment.Decorators;
using Ultimate_Boxing_Simulator.Fighters;
using Ultimate_Boxing_Simulator.Fighters.States;
using Ultimate_Boxing_Simulator.Strategies.CoefficientStrategies;

namespace Ultimate_Boxing_Simulator
{
    public partial class MainWindow : Window
    {
        private List<EnemyFighter> _enemies;
        private EnemiesGenerator _enemiesGenerator;
        private List<object> _shopItems;
        private int _index = 0;
        private int enemiesAmount = 10;
        private IFighter _character;
        private ShopFacade _shopFacade;

        public MainWindow()
        {
            _character = new MainCharacterProxy(MainCharacter.Instance);
            var character = _character as MainCharacterProxy;
            character.SetStrategy(new BaseCoefficientStrategy());
            _shopFacade = new ShopFacade(_character);
            _enemiesGenerator = new EnemiesGenerator();
            _enemies = _enemiesGenerator.Generate(enemiesAmount);
            InitializeComponent();
            playerStatsPanel.DataContext = _character;
            moneyText.DataContext = _character;
            bottomPanel.DataContext = _character;
            LogPanel.DataContext = _character as MainCharacterProxy;
            enemyStatsPanel.DataContext = _enemies[_index];
            _character.UpdatePrediction(_enemies[_index]);
            AbstractFactory cheapFactory = new CheapEquipmentFactory();
            AbstractFactory mediumFactory = new MediumEquipmentFactory();
            AbstractFactory expensiveFactory = new ExpensiveEquipmentFactory();
            _shopItems = new List<object>
            {
                cheapFactory.CreateGloves(),
                cheapFactory.CreateJacket(),
                cheapFactory.CreateFootwear(),
                new ReinforcedGloves(cheapFactory.CreateGloves()),
                new ReinforcedJacket(cheapFactory.CreateJacket()),
                new ReinforcedFootwear(cheapFactory.CreateFootwear()),
                mediumFactory.CreateGloves(),
                mediumFactory.CreateJacket(),
                mediumFactory.CreateFootwear(),
                expensiveFactory.CreateGloves(),
                expensiveFactory.CreateJacket(),
                expensiveFactory.CreateFootwear(),
                new EnergyDrink("Енергетик", 20, "icons/energyDrink.png"),
                new HealingPot("Ліки", 30, "icons/healingPot.jpg")
            };
            CheapItemsList.ItemsSource = _shopItems.Take(3);
            ReinforcedCheapItemsList.ItemsSource = _shopItems.Skip(3).Take(3);
            MediumItemsList.ItemsSource = _shopItems.Skip(6).Take(3);
            ExpensiveItemsList.ItemsSource = _shopItems.Skip(9).Take(3);
            BoostersList.ItemsSource = _shopItems.Skip(12);
        }

        private void shop_button_Click(object sender, RoutedEventArgs e)
        {
            playerStatsPanel.Visibility = Visibility.Collapsed;
            enemyStatsPanel.Visibility = Visibility.Collapsed;
            shop_panel.Visibility = Visibility.Visible;
            leaveShop_button.Visibility = Visibility.Visible;
            backButtonGrid.Visibility = Visibility.Visible;
            bottomPanel.Visibility = Visibility.Collapsed;
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var element = button.DataContext;
            _shopFacade.BuyItem(element);
        }

        private void fight_button_click(object sender, RoutedEventArgs e)
        {
            if (_index >= enemiesAmount)
                return;
            var mainCharacter = _character as MainCharacterProxy;
            if (mainCharacter.CanFight())
            {
                double characterCoef = _character.BettingCoefficient;
                double enemyCoef = _enemies[_index].BettingCoefficient;
                if (characterCoef > enemyCoef)
                {
                    MessageBox.Show("Перемога у бою. Нагорода: 100 кредитів.", "Перемога!", MessageBoxButton.OK, MessageBoxImage.Information);
                    ++_index;
                    _character.UpdateMoney(100);
                }
                else
                {
                    MessageBox.Show("Поразка у бою. Нагорода: 10 кредитів.", "Поразка!", MessageBoxButton.OK, MessageBoxImage.Information);
                    ++_index;
                    _character.UpdateMoney(10);
                }
                if (_index >= enemiesAmount)
                {
                    enemyStatsPanel.DataContext = null;
                }
                else
                {
                    _character.UpdatePrediction(_enemies[_index]);
                    enemyStatsPanel.DataContext = _enemies[_index];
                }

                var random = new Random();
                if (random.NextDouble() <= 0.2)
                {
                    var character = _character as MainCharacterProxy;
                    character.SetState(new InjuredState());
                }
                else if (random.NextDouble() <= 0.4)
                {
                    var character = _character as MainCharacterProxy;
                    character.SetState(new TiredState());
                }
            }
            else
            {
                var character = _character as MainCharacterProxy;
                MessageBox.Show(character.Status, "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backButton_click(object sender, RoutedEventArgs e)
        {
            playerStatsPanel.Visibility = Visibility.Visible;
            enemyStatsPanel.Visibility = Visibility.Visible;
            shop_panel.Visibility = Visibility.Collapsed;
            leaveShop_button.Visibility = Visibility.Collapsed;
            backButtonGrid.Visibility = Visibility.Collapsed;
            _character.UpdatePrediction(_enemies[_index]);
            bottomPanel.Visibility = Visibility.Visible;
        }

        private void ShowLogButton_Click(object sender, RoutedEventArgs e)
        {
            LogPanel.Visibility = Visibility.Visible;
            bottomPanel.Visibility = Visibility.Collapsed;
        }

        private void CloseLogButton_Click(object sender, RoutedEventArgs e)
        {
            LogPanel.Visibility = Visibility.Collapsed;
            bottomPanel.Visibility = Visibility.Visible;
        }

        private void StrategyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedItem = comboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;

            var character = _character as MainCharacterProxy;
            switch (selectedItem.Content.ToString())
            {
                case "Базова":
                    character.SetStrategy(new BaseCoefficientStrategy());
                    break;
                case "Збільшена вага швидкості":
                    character.SetStrategy(new IncreasedSpeedValueStrategy());
                    break;
            }
            if (_index < enemiesAmount)
            {
                _character.UpdatePrediction(_enemies[_index]);
                bottomPanel.DataContext = null;
                bottomPanel.DataContext = _character;
            }
        }
    }
}