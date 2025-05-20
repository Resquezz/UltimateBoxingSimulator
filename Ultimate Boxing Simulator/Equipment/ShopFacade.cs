using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Equipment.Concrete_Products;
using Ultimate_Boxing_Simulator.Equipment.Decorators;
using Ultimate_Boxing_Simulator.Equipment.PurchaseHandlers;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment
{
    public class ShopFacade
    {
        private IFighter _character;
        private BasePurchaseHandler _handlersChain;
        public ShopFacade(IFighter character)
        {
            _handlersChain = new FootwearPurchaseHandler();
            var glovesHandler = new GlovesPurchaseHandler();
            var jacketHandler = new JacketPurchaseHandler();
            var boostersHandler = new BoostersHandler();
            _handlersChain.SetNext(glovesHandler);
            glovesHandler.SetNext(jacketHandler);
            jacketHandler.SetNext(boostersHandler);
            _character = character;
        }
        public void BuyItem(object element)
        {
            _handlersChain.Handle(_character, element);
        }
    }
}
