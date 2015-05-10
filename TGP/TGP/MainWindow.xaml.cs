using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace TGP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected String Xaxis="EMP1";
        protected String Yaxis="EMP1";
        protected String[] Commonaxis = new String[]{ "0", "1", "0", "0", "1", "0", "1", "0","1"};
        protected String Wave = "TGP_WV1";
        Dictionary<string, string> xdata_row_pos = new Dictionary<string, string>();
        Dictionary<string, string> ydata_row_pos = new Dictionary<string, string>();
        Dictionary<string, string> xdata_row_count = new Dictionary<string, string>();
        Dictionary<string, string> ydata_row_count = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
           
        }


        protected string RadioButtonGroupName { get; set; }
       
        private void createRadioButtonsChildren(string content, TreeViewItem item)
        {
            TreeViewItem childRadio = new TreeViewItem()
            {
                Header = new RadioButton()
                {
                    Content = content,
                    GroupName = RadioButtonGroupName
                }
               
            };
           
            item.Items.Add(childRadio);
            RadioButton rad = (RadioButton)childRadio.Header;
            rad.Checked += new RoutedEventHandler(RadioButton_Checked);
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
         
           
            ItemCollection itemsX = this.treeViewXaxis.Items;
            foreach (TreeViewItem it in itemsX)
            {

                TreeViewItem x = (TreeViewItem)it;
                foreach (TreeViewItem ite in x.Items)
                {
                    RadioButton y = (RadioButton)ite.Header;
                    if (y.IsChecked ?? false)
                    {
                        Xaxis=y.Content.ToString();

                    }
                }

            }

            ItemCollection itemsY = this.treeViewYaxis.Items;
            foreach (TreeViewItem it in itemsY)
            {

                TreeViewItem x = (TreeViewItem)it;
                foreach (TreeViewItem ite in x.Items)
                {
                    RadioButton y = (RadioButton)ite.Header;
                    if (y.IsChecked ?? false)
                    {
                        Yaxis=y.Content.ToString();

                    }
                }

            }
        }
       
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            int i = 0;
            ItemCollection itemsY = this.treeViewCommonaxis.Items;
            foreach (TreeViewItem it in itemsY)
            {
                
                if (it.Header.ToString().EndsWith("True"))
                    Commonaxis[i]="1";
                else
                    Commonaxis[i]="0";
                i++;
            }
        }
        private TreeViewItem createParentInTree(string content, TreeView tree)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = content;
            tree.Items.Add(item);
            return item;
        }
        private void createCheckBox(string content, TreeView tree)
        {
            TreeViewItem childCheckBox = new TreeViewItem()
            {
                Header = new CheckBox()
                {
                    Content = content
                }
            };

            tree.Items.Add(childCheckBox);
            CheckBox rad = (CheckBox)childCheckBox.Header;
            rad.Checked += new RoutedEventHandler(CheckBox_Checked);

        }
        private void treeViewYaxis_Loaded(object sender, RoutedEventArgs e)
        {
           
            
            string select = "SELECT * FROM TGP_WV1";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, "Data Source=winserv1;Initial Catalog=AdventureWorksDW;Integrated Security=True"); //connection string
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            RadioButtonGroupName = "XSingleGroup";
            TreeViewItem parentemp = createParentInTree("Employment", treeViewYaxis);
            TreeViewItem parentinc = createParentInTree("Income", treeViewYaxis);
            TreeViewItem parenthls = createParentInTree("Health LifeStyle", treeViewYaxis);
            TreeViewItem parentho = createParentInTree("Housing", treeViewYaxis);
            TreeViewItem parentprs = createParentInTree("Social Support", treeViewYaxis);
            TreeViewItem parentsoc = createParentInTree("Social Connections", treeViewYaxis);
            TreeViewItem parentscom = createParentInTree("Social Comparision", treeViewYaxis);
            TreeViewItem parentar = createParentInTree("Attitude towards Relocation", treeViewYaxis);
            TreeViewItem parentph = createParentInTree("Physical Health", treeViewYaxis);
            TreeViewItem parentmh = createParentInTree("Mental Health", treeViewYaxis);
            TreeViewItem parentsc = createParentInTree("Sense Of Control", treeViewYaxis);
            TreeViewItem parentse = createParentInTree("Self Esteem", treeViewYaxis);
            TreeViewItem parentle = createParentInTree("Life Events", treeViewYaxis);

            foreach (DataColumn column in ds.Tables[0].Columns)
            {
               

                if (column.ColumnName.StartsWith("EMP"))
                {
                    
                    createRadioButtonsChildren(column.ColumnName, parentemp);
              
                }
                else if (column.ColumnName.StartsWith("INC"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentinc);

                }
                else if (column.ColumnName.StartsWith("HLS"))
                {

                    createRadioButtonsChildren(column.ColumnName, parenthls);

                }
                else if (column.ColumnName.StartsWith("HO"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentho);

                }
                else if (column.ColumnName.StartsWith("PRS"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentprs);

                }
                else if (column.ColumnName.StartsWith("SOC"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentsoc);

                }
                else if (column.ColumnName.StartsWith("SCOM"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentscom);

                }
                else if (column.ColumnName.StartsWith("AR"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentar);

                }
                else if (column.ColumnName.StartsWith("PH"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentph);


                }
                else if (column.ColumnName.StartsWith("MH"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentmh);


                }
                else if (column.ColumnName.StartsWith("SC"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentsc);


                }
                else if (column.ColumnName.StartsWith("SE"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentse);


                }
                else if (column.ColumnName.StartsWith("LE"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentle);

                }
            }
        }

        private void treeViewXaxis_Loaded(object sender, RoutedEventArgs e)
        {
            

            string select = "SELECT * FROM TGP_WV1";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, "Data Source=winserv1;Initial Catalog=AdventureWorksDW;Integrated Security=True"); // connection string
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            RadioButtonGroupName = "YSingleGroup";
            TreeViewItem parentemp = createParentInTree("Employment", treeViewXaxis);
            TreeViewItem parentinc = createParentInTree("Income", treeViewXaxis);
            TreeViewItem parenthls = createParentInTree("Health LifeStyle", treeViewXaxis);
            TreeViewItem parentho = createParentInTree("Housing", treeViewXaxis);
            TreeViewItem parentprs = createParentInTree("Social Support", treeViewXaxis);
            TreeViewItem parentsoc = createParentInTree("Social Connections", treeViewXaxis);
            TreeViewItem parentscom = createParentInTree("Social Comparision", treeViewXaxis);
            TreeViewItem parentar = createParentInTree("Attitude towards Relocation", treeViewXaxis);
            TreeViewItem parentph = createParentInTree("Physical Health", treeViewXaxis);
            TreeViewItem parentmh = createParentInTree("Mental Health", treeViewXaxis);
            TreeViewItem parentsc = createParentInTree("Sense Of Control", treeViewXaxis);
            TreeViewItem parentse = createParentInTree("Self Esteem", treeViewXaxis);
            TreeViewItem parentle = createParentInTree("Life Events", treeViewXaxis);

            foreach (DataColumn column in ds.Tables[0].Columns)
            {


                if (column.ColumnName.StartsWith("EMP"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentemp);

                }
                else if (column.ColumnName.StartsWith("INC"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentinc);

                }
                else if (column.ColumnName.StartsWith("HLS"))
                {

                    createRadioButtonsChildren(column.ColumnName, parenthls);

                }
                else if (column.ColumnName.StartsWith("HO"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentho);

                }
                else if (column.ColumnName.StartsWith("PRS"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentprs);

                }
                else if (column.ColumnName.StartsWith("SOC"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentsoc);

                }
                else if (column.ColumnName.StartsWith("SCOM"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentscom);

                }
                else if (column.ColumnName.StartsWith("AR"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentar);

                }
                else if (column.ColumnName.StartsWith("PH"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentph);


                }
                else if (column.ColumnName.StartsWith("MH"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentmh);


                }
                else if (column.ColumnName.StartsWith("SC"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentsc);


                }
                else if (column.ColumnName.StartsWith("SE"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentse);


                }
                else if (column.ColumnName.StartsWith("LE"))
                {

                    createRadioButtonsChildren(column.ColumnName, parentle);

                }
            
            }
        }
        private void treeViewCommonaxis_Loaded(object sender, RoutedEventArgs e)
        {

            createCheckBox("Age1 < 30", treeViewCommonaxis);
            createCheckBox("30 <= Age2 <= 50", treeViewCommonaxis);
            createCheckBox("Age3 > 50", treeViewCommonaxis);
            createCheckBox("Non-Migrant", treeViewCommonaxis);
            createCheckBox("Migrant", treeViewCommonaxis);
            createCheckBox("NoMove", treeViewCommonaxis);
            createCheckBox("OutMove", treeViewCommonaxis);
            createCheckBox("UpMove", treeViewCommonaxis);
            createCheckBox("Gender", treeViewCommonaxis);

        }

        private void MySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue.ToString().Equals("0"))
                Wave = "TGP_WV1";
            else if (e.NewValue.ToString().Equals("1"))
                Wave = "TGP_WV2";

        }
        private Brush PickRandomBrush()
        {
            Brush result = Brushes.Transparent;
            Random rnd = new Random();
            Type brushesType = typeof(Brushes);
            PropertyInfo[] properties = brushesType.GetProperties();
            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);
            return result;
        } 
        private void DrawGraph_Click(object sender, RoutedEventArgs e)
        {

            

            //Clears all the chart area
            chartArea.Children.Clear();
            xdata_row_pos.Clear();//clear the values 
            ydata_row_pos.Clear();//clear the values 
            xdata_row_count.Clear();
            ydata_row_count.Clear();


            // Draw Xaxis Line
            
            //Get X Axis values from database
            string selectx = "SELECT " + Xaxis + ", Count(*) as COUNT FROM " + Wave + " WHERE " + Xaxis + "!='' AND " + Xaxis + "!='?' AND (age1='" + Commonaxis[0] + "' OR age2='" + Commonaxis[1] + "' OR age3='" + Commonaxis[2] + "' ) AND nonmig='" + Commonaxis[3] + "' AND mig='" + Commonaxis[4] + "' AND nomove='" + Commonaxis[5] + "' AND outmove='" + Commonaxis[6] + "' AND upmove='" + Commonaxis[7] + "' AND GENDER='" + Commonaxis[8] + "' GROUP BY " + Xaxis + " ORDER BY " + Xaxis + " ";
            SqlDataAdapter dataAdapterx = new SqlDataAdapter(selectx, "Data Source=winserv1;Initial Catalog=AdventureWorksDW;Integrated Security=True"); //connection string
            SqlCommandBuilder commandBuildexr = new SqlCommandBuilder(dataAdapterx);
            DataSet dsx = new DataSet();
            dataAdapterx.Fill(dsx);

            foreach (DataRow row in dsx.Tables[0].Rows)
            {
                xdata_row_count.Add(row[0].ToString(),row[1].ToString());
             
            }

            //Printing out the axis values
            const double margin = 20;
            double xmin = 40;
            double xmax = chartArea.Width;
            double ymin = this.chartArea.Height;
            double ymax = chartArea.Height - 40;
            double step = 40;
            step = (chartArea.Width - 30) / xdata_row_count.Count;
           

            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(new Point(0, ymax), new Point(chartArea.Width, ymax)));
            double xa = 0;
            GeometryGroup xaxis_lblgeom = new GeometryGroup();
            xa = xmin;
            foreach (var pairx in xdata_row_count)
            {
                xaxis_geom.Children.Add(new LineGeometry(new Point(xa, ymax - margin / 2), new Point(xa, ymax + margin / 2)));
                Label xlabel = new Label();
                xlabel.Content = pairx.Key.ToString();
                xlabel.Height = 50;
                xlabel.Width = 50;
                xlabel.Margin = new Thickness(xa, ymax + margin / 2, 0, 0);
                chartArea.Children.Add(xlabel);
                xdata_row_pos.Add(pairx.Key.ToString(),xa.ToString());
                xa += step;
            }

            Path xaxis_path = new Path();
            xaxis_path.StrokeThickness = 1;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            chartArea.Children.Add(xaxis_path);

            // Draw Yaxis Line

            //Get Y Axis values from database

            string selecty = "SELECT " + Yaxis + ", Count(*) as COUNT FROM " + Wave + " WHERE " + Yaxis + "!='' AND " + Yaxis + "!='?' AND (age1='" + Commonaxis[0] + "' OR age2='" + Commonaxis[1] + "' OR age3='" + Commonaxis[2] + "') AND nonmig='" + Commonaxis[3] + "' AND mig='" + Commonaxis[4] + "' AND nomove='" + Commonaxis[5] + "' AND outmove='" + Commonaxis[6] + "' AND upmove='" + Commonaxis[7] + "' AND GENDER='" + Commonaxis[8] + "' GROUP BY " + Yaxis + " ORDER BY " + Yaxis + " ";
            SqlDataAdapter dataAdaptery = new SqlDataAdapter(selecty, "Data Source=winserv1;Initial Catalog=AdventureWorksDW;Integrated Security=True"); //connection string
            SqlCommandBuilder commandBuildery = new SqlCommandBuilder(dataAdaptery);
            DataSet dsy = new DataSet();
            dataAdaptery.Fill(dsy);
            foreach (DataRow row in dsy.Tables[0].Rows)
            {
                ydata_row_count.Add(row[0].ToString(), row[1].ToString());
     
            }

            //Y-Axis
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(new Point(xmin, 0), new Point(xmin, chartArea.Height)));
            double y = 0;
            step = (chartArea.Height - 40) / ydata_row_count.Count;
            y = chartArea.Height - 40;
            foreach (var pairy in ydata_row_count)
            {
                yaxis_geom.Children.Add(new LineGeometry(new Point(xmin - margin / 2, y), new Point(xmin + margin / 2, y)));
                Label ylabel = new Label();
                ylabel.Content =  pairy.Key.ToString();
                ylabel.Height = 50;
                ylabel.Width = 50;
                ylabel.Margin = new Thickness(xmin-30, y-20, 0, 0);
                chartArea.Children.Add(ylabel);
                ydata_row_pos.Add(pairy.Key.ToString(), y.ToString());
                 y -= step;
            }

            Path yaxis_path = new Path();
            yaxis_path.StrokeThickness = 1;
            yaxis_path.Stroke = Brushes.Black;
            yaxis_path.Data = yaxis_geom;
            chartArea.Children.Add(yaxis_path);

            //Draw the ellipse
            if (xdata_row_pos.Count != 0 && ydata_row_pos.Count != 0)
            {
                foreach (var xpair in xdata_row_pos)
                {
                    foreach (var ypair in ydata_row_pos)
                    {
                        if (xpair.Key == ypair.Key)
                        {

                            Ellipse myEllipse = new Ellipse();
                            myEllipse.Fill =PickRandomBrush();//Brushes.Transparent; Pick a random brush color
                            myEllipse.StrokeThickness = 1;
                            myEllipse.Stroke = Brushes.Black;
                            myEllipse.Margin = new Thickness(Convert.ToDouble(xpair.Value), Convert.ToDouble(ypair.Value), 0, 0);//Set co-ordinates on canvas
                            myEllipse.Width = Convert.ToDouble(ydata_row_count[ypair.Key]);
                            myEllipse.Height = Convert.ToDouble(xdata_row_count[xpair.Key]);
                            myEllipse.ToolTip = "CountOf " + Xaxis + ": " + Convert.ToDouble(ydata_row_count[ypair.Key]).ToString() + " CountOf " + Yaxis + ": " + Convert.ToDouble(xdata_row_count[xpair.Key]).ToString();
                            chartArea.Children.Add(myEllipse);

                        }
                    }
                }
                //Elipse Drawn
            }
            else if (xdata_row_pos.Count == 0 && ydata_row_pos.Count == 0)
            {
                MessageBox.Show("No such values in data set! Try selecting different options ");
                
            }
           


        }//End of DrawGraph_Click


    }
}
