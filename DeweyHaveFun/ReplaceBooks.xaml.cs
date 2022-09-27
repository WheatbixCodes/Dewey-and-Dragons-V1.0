
//using javax.tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ComponentModel;

namespace DeweyHaveFun
{
    
    public partial class ReplaceBooks : Window
    {
        ListView list = new ListView();
        string test = "hello";
        int call1 = 0;
        Random rnd = new Random();
        int count = 10;
        int call2 = 0;
        int call3 = 0;
        string split = ".";
        Stopwatch timer = new Stopwatch();
        private bool populateButtonClicked = false;
        DispatcherTimer dt = new DispatcherTimer();
        ListBoxItem item = new ListBoxItem();
        ListBoxItem temp = new ListBoxItem();
        int temp1=  0;
        CustomDictionary<int, string> cd = new CustomDictionary<int, string>();
        string correct1 = "";
        public int timed = 0;
        public int correctNum = 0;

        

        public ReplaceBooks()
        {
           
            InitializeComponent();
        }
        public ReplaceBooks(string test)
        {
            this.test = test;
        }


        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            ReplaceBooksHelp rp = new ReplaceBooksHelp();
            rp.Show();
        }
            

        private void generatedList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void populateBtn_Click(object sender, RoutedEventArgs e)
        {
            //https://social.msdn.microsoft.com/Forums/silverlight/en-US/47c335e9-0cd6-48a0-abe8-edd9d6d864e0/dispatchertimer-reset-interval?forum=silverlightnet 
            //https://stackoverflow.com/questions/38544094/how-to-pass-values-from-one-class-to-another-class-using-wpf


            cd = new CustomDictionary<int, string>();

            populateButtonClicked = true;
            if (populateButtonClicked == true)
            {
                timed = 0;
                lblTimer.Content = timed.ToString();
                generatedList.Items.Clear();
                checkList.Items.Clear();
                timer.Start();
                populateBtn.IsEnabled = false;

                for (int i = 0; i < count; i++)
                {
                     item = new ListBoxItem();

                    string numberTemp = generateCallNumbers();



                    cd.Add(i, numberTemp);

                    item.Content = numberTemp;
                   

                   generatedList.Items.Add(item);

                   
                }

                dt.Tick -= Dt_Tick;
            }
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Stop();
            
            dt.Start();
           
        }

        public string generateCallNumbers()
        {
            string number = "";

            call1 = rnd.Next(1000);

           call2 = rnd.Next(10000);

            
            if (call1 < 10 )
            {
                number += "00" + call1;
            }
            else if(call1 < 100)
            {
                number += "0" + call1;
            }
            else
            {
                number += call1;
            }
                number += "." + call2;
            

            return number; 
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            List<string> answers = new List<string>();
            dt.Stop();
            populateBtn.IsEnabled = true;
            for (int i = 0; i < 10; i++)
            {
               

                    ListBoxItem itemAnswer = checkList.Items[i] as ListBoxItem;

                    answers.Add(itemAnswer.Content.ToString());
                
            }
            
            checkList.Items.Clear();
            
            cd.Sort();
            
            
            
            for (int i = 0; i < 10; i++)
            {

                ListBoxItem correct = new ListBoxItem();
                ListBoxItem itemAnswer= new ListBoxItem();
                

                
                correct.Content = cd[i];
               itemAnswer.Content = answers[i];
                correct1 = correct.ToString();


                if (answers[i].Equals(cd[i]))
                {
                    itemAnswer.Background = Brushes.Green;
                }
                else
                {
                    itemAnswer.Background = Brushes.Orange;
                }
                if(correct1 != itemAnswer.ToString())
                {
                    correctNum += 0; 
                }
                else
                {
                    correctNum += 1;
                }

                generatedList.Items.Add(correct);
                checkList.Items.Add(itemAnswer);
 
            }

            if (timed > 35)
            {
                TimeOut tt = new TimeOut();
                tt.Show();
            }
            if (correctNum >=7 && timed <= 35)
            {
                ReplaceBooksSuccess rbs = new ReplaceBooksSuccess();
                rbs.Show();
            }
            else
            {
                Incorrect incorrect = new Incorrect();
                incorrect.Show();
            }
            

        }

        private void answerCheck()
        {
            if (checkList.Items.Count > 9)
            {
                btnCheck.IsEnabled = true;
            }
            else
            {
                btnCheck.IsEnabled = false;
            }
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            timed++;

            lblTimer.Content = timed.ToString();

        }

        private void generatedList_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);

            if (e.LeftButton == MouseButtonState.Pressed && 
                Math.Abs(mousePos.X) > SystemParameters.MinimumHorizontalDragDistance && 
                Math.Abs(mousePos.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                try
                {
                    ListBoxItem selectedItem = (ListBoxItem)generatedList.SelectedItem;

                    generatedList.Items.Remove(selectedItem);

                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Copy);

                    if (selectedItem.Parent == null)
                    {
                        generatedList.Items.Add(selectedItem);
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void generatedList_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop)is ListBoxItem listItem)
            {
                generatedList.Items.Add(listItem);
                answerCheck();
            }
        }
        
    private void checkList_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(mousePos.X) > SystemParameters.MinimumHorizontalDragDistance &&
                Math.Abs(mousePos.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                try
                {
                    ListBoxItem itemSelected = (ListBoxItem)checkList.SelectedItem;

                    checkList.Items.Remove(itemSelected);

                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, itemSelected), DragDropEffects.Copy);

                    if (itemSelected.Parent == null)
                    {
                        checkList.Items.Add(itemSelected);
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void checkList_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is ListBoxItem listItem)
            {
                checkList.Items.Add(listItem);
                answerCheck();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dt.Stop();
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }

        
    }
    }
