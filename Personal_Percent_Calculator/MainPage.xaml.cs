using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Personal_Percent_Calculator
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Personal_Percent_Calculator.Common.LayoutAwarePage
    {
        public static List<PercentItem> PercentItemsList;
        public string PercentageType = "";
        public MainPage()
        {
            this.InitializeComponent();
            PercentItemsList = new List<PercentItem>();
            PercentItemsList.Add(new PercentItem { PercentName = "Percent Calculator", PercentDescription = "e.g. What is 30% of $29.99?" });
            PercentItemsList.Add(new PercentItem { PercentName = "Percent Increase", PercentDescription = "e.g. 20 + (20 * 5%) = 21" });
            PercentItemsList.Add(new PercentItem { PercentName = "Percent Discount", PercentDescription = "e.g. 40% off $79.99" });
            PercentItemsList.Add(new PercentItem { PercentName = "Tip Calculator", PercentDescription = "A simple tip calculator" });
            PercentItemsList.Add(new PercentItem { PercentName = "Percent Change", PercentDescription = "e.g. $4.99 to $8.99 = 80.16% increase" });
            PercentItemsList.Add(new PercentItem { PercentName = "Percentage", PercentDescription = "e.g. 15 is X percent of 45? X = 33.33" });

            itemListView.ItemsSource = PercentItemsList;

           
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            string number1 = "", number2 = "";
            double result = 0.0; 
            switch (PercentageType)
            {
                case "Percent Calculator":
                    number1 = txtBox1.Text;
                    number2 = txtBox2.Text;
                    try
                    {
                        result = ((Math.Round(Convert.ToDouble(number1),2) / 100) * Math.Round(Convert.ToDouble(number2),2));
                        resultsTxtBlock.Text = Math.Round(result, 2).ToString();
                    }
                    catch { }
                    break;
                case "Percent Increase":
                    number1 = txtBox1.Text;
                    number2 = txtBox2.Text;
                    
                    try
                    {
                        result = (Math.Round(Convert.ToDouble(number1), 2)) * Math.Round((Convert.ToDouble(number2) / 100),2);
                        resultsTxtBlock.Text = Math.Round(result, 2).ToString(); 
                    }
                    catch { }
                    break;
                case "Percent Discount":
                    number1 = txtBox1.Text;
                    number2 = txtBox2.Text;
                    try
                    {
                        result = ((Math.Round(Convert.ToDouble(number1),2) - ((Math.Round(Convert.ToDouble(number1),2) * (Math.Round(Convert.ToDouble(number2)/100,2))))));
                        resultsTxtBlock.Text = Math.Round(result,2).ToString();
                    }
                    catch { }
                    break;
                case "Tip Calculator":
                    number1 = txtBox1.Text;
                    number2 = txtBox2.Text;
                    try
                    {
                        result = (Math.Round(Convert.ToDouble(number1),2) * Math.Round(Convert.ToDouble(number2)/100,2)) + Math.Round(Convert.ToDouble(number1),2);
                        resultsTxtBlock.Text = "$" + Math.Round(result, 2).ToString();
                    }
                    catch { }
                    break;
                case "Percent Change":
                    number1 = txtBox1.Text;
                    number2 = txtBox2.Text;
                    try
                    {
                        result = (Math.Round(Math.Abs((Convert.ToDouble(number1))), 2) - Math.Round(Convert.ToDouble(number2), 2)) / (Math.Round(Convert.ToDouble(number1), 2));
                        resultsTxtBlock.Text = Math.Round(result, 2).ToString();
                    }
                    catch { }
                    break;
                case "Percentage":
                    number1 = txtBox1.Text;
                    number2 = txtBox2.Text;
                    try
                    {
                        result = (Math.Round(Convert.ToDouble(number1),2))/(Math.Round(Convert.ToDouble(number2),2));
                        resultsTxtBlock.Text = Math.Round(result, 2).ToString();
                    }
                    catch { }
                    break;
                default: break; 
            }

        }

        private void itemListView_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var percent_name = (e.ClickedItem as PercentItem).PercentName;
            
            switch (percent_name)
            {
                case "Percent Calculator":
                    PercentageType = "Percent Calculator";
                    txtBlock1.Text = "What is";
                    txtBlock2.Text = "of";
                    txtBlock3.Text = "%";
                    txtBlock4.Text = ""; 
                    break;
                case "Percent Increase":
                    PercentageType = "Percent Increase";
                    txtBlock1.Text = "Initial amount";
                    txtBlock2.Text = "Increased by";
                    txtBlock3.Text = "";
                    txtBlock4.Text = "%"; 
                    break;
                case "Percent Discount":
                    PercentageType = "Percent Discount";
                    txtBlock1.Text = "Initial amount";
                    txtBlock2.Text = "Discount percentage";
                    txtBlock3.Text = "";
                    txtBlock4.Text = "%"; 
                    break;
                case "Tip Calculator":
                    PercentageType = "Tip Calculator";
                    txtBlock1.Text = "Total amount";
                    txtBlock2.Text = "Tip percentage";
                    txtBlock3.Text = "";
                    txtBlock4.Text = "%"; 
                    break;
                case "Percent Change":
                    PercentageType = "Percent Change";
                    txtBlock1.Text = "From value";
                    txtBlock2.Text = "To value";
                    txtBlock3.Text = "";
                    txtBlock4.Text = "%"; 
                    break;
                case "Percentage":
                    PercentageType = "Percentage";
                    txtBlock1.Text = "";
                    txtBlock2.Text = "is what percent of";
                    txtBlock3.Text = "";
                    txtBlock4.Text = "?"; 
                    break;
                default: break; 

            }

            pageTitle.Text = PercentageType;

        }

        private void txtBox1_KeyUp_1(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                calculateButton_Click(sender, e);
            }
        }



        private void txtBox2_KeyUp_1(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                calculateButton_Click(sender, e);
            }
        }
    }
}
