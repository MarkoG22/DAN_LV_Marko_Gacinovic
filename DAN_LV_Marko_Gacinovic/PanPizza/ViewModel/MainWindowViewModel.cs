﻿using PanPizza.Commands;
using PanPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PanPizza.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;

        #region Properties
        private tblPizza pizza;
        public tblPizza Pizza
        {
            get { return pizza; }
            set { pizza = value; OnPropertyChanged("Pizza"); }
        }

        private tblSize size;
        public tblSize Size
        {
            get { return size; }
            set { size = value; OnPropertyChanged("Size"); }
        }

        private List<tblSize> sizeList;
        public List<tblSize> SizeList
        {
            get { return sizeList; }
            set { sizeList = value; OnPropertyChanged("SizeList"); }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion

        // constructor
        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
            pizza = new tblPizza();
            SizeList = GetAllSize();
        }

        #region Commands
        // command for saving data to the database
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        /// <summary>
        /// method for enabling Save button
        /// </summary>
        /// <returns></returns>
        private bool CanSaveExecute()
        {
            if (size != null && price != 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// method for adding pizza to the database
        /// </summary>
        private void SaveExecute()
        {
            try
            {
                using (PanPizzaEntities context = new PanPizzaEntities())
                {
                    tblPizza newPizza = new tblPizza();                    

                    newPizza.SizeID = size.SizeID;
                    newPizza.Salami = pizza.Salami;
                    newPizza.Ham = pizza.Ham;
                    newPizza.Kulen = pizza.Kulen;
                    newPizza.Ketchup = pizza.Ketchup;
                    newPizza.Mayonnaise = pizza.Mayonnaise;
                    newPizza.HotPepper = pizza.HotPepper;
                    newPizza.Olives = pizza.Olives;
                    newPizza.Oregano = pizza.Oregano;
                    newPizza.Sesame = pizza.Sesame;
                    newPizza.Cheese = pizza.Cheese;

                    newPizza.PizzaID = pizza.PizzaID;
                    newPizza.Price = price;

                    context.tblPizzas.Add(newPizza);
                    context.SaveChanges();

                    MessageBox.Show("The new pizza added successfully");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong inputs, please check your size input.");
            }
        }

        // command for calculating the amount
        private ICommand calculate;
        public ICommand Calculate
        {
            get
            {
                if (calculate == null)
                {
                    calculate = new RelayCommand(param => CalculateExecute(), param => CanCalculateExecute());
                }
                return calculate;
            }
        }

        /// <summary>
        /// method for Calculate button
        /// </summary>
        /// <returns></returns>
        private bool CanCalculateExecute()
        {
            if (size != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// method for calculating the amount
        /// </summary>
        private void CalculateExecute()
        {
            try
            {
                if (size.SizeName == "Small")
                {
                    price = 300;
                }
                else if (size.SizeName == "Medium")
                {
                    price = 500;
                }
                else if (size.SizeName == "Big")
                {
                    price = 700;
                }

                if (pizza.Salami == true)
                {
                    price += 15;
                }
                if (pizza.Ham == true)
                {
                    price += 15;
                }
                if (pizza.Kulen == true)
                {
                    price += 15;
                }
                if (pizza.Ketchup == true)
                {
                    price += 10;
                }
                if (pizza.Mayonnaise == true)
                {
                    price += 10;
                }
                if (pizza.HotPepper == true)
                {
                    price += 15;
                }
                if (pizza.Olives == true)
                {
                    price += 18;
                }
                if (pizza.Oregano == true)
                {
                    price += 12;
                }
                if (pizza.Sesame == true)
                {
                    price += 12;
                }
                if (pizza.Cheese == true)
                {
                    price += 15;
                }

                MessageBox.Show("Your amount to pay is: " + price + " DIN");
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong inputs, please check your size input.");
            }
        }

        // command for closing the window
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        /// <summary>
        /// method for closing the window
        /// </summary>
        private void CloseExecute()
        {
            try
            {
                main.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// method for getting all sizes to the list
        /// </summary>
        /// <returns></returns>
        private List<tblSize> GetAllSize()
        {
            try
            {
                using (PanPizzaEntities context = new PanPizzaEntities())
                {
                    List<tblSize> list = new List<tblSize>();
                    list = (from x in context.tblSizes select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        #endregion
    }
}
