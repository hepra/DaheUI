using System;
using System.Reflection;
using System.Text;

namespace UIFrameworkCore.Helper
{
    public class UI生成器
    {
      public  static  string Xaml<T>( T CLASS)
        {
            StringBuilder code = new StringBuilder();
            Type type = CLASS.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
 
            code.AppendLine("<Grid Name=\"gridAdd\"  Height=\"1080\" Width=\"1920\"  Background=\"#F4F4F4\">");
            code.AppendLine("<ScrollViewer  Style=\"{ StaticResource AduScrollViewer}\">");
            code.AppendLine("<Grid >");
            code.AppendLine("<Grid.RowDefinitions>");
            for (int i = 0; i < propertyInfos.Length; i++)
            {
               
                code.AppendLine("  <RowDefinition Height=\"auto\" ></RowDefinition>");
            }
            int rowNum=  0;
            code.AppendLine("</Grid.RowDefinitions>");

            code.AppendLine($"<Grid Height=\"60\"  Grid.Row=\"{rowNum}\" >");
            code.AppendLine("  <TextBlock   Style=\"{ StaticResource myTextModifyDabaseData}\" FontSize=\"40\" HorizontalAlignment=\"Center\"  Text=\"标题\" Grid.Column=\"0\"></TextBlock>");
            code.AppendLine(" </Grid>");
            rowNum++;
            foreach (PropertyInfo item in propertyInfos)
            {
                if(item.Name=="Id")
                {
                    continue;
                }
                string NAME = item.Name;//
                string TYPE = item.PropertyType.ToString();
                code.AppendLine($"<Grid  Grid.Row=\"{rowNum}\" >");
                code.AppendLine(" <Grid.ColumnDefinitions >");
                code.AppendLine(" <ColumnDefinition Width = \"260\"></ColumnDefinition >");
                code.AppendLine(" <ColumnDefinition Width = \"*\"></ColumnDefinition >");
                code.AppendLine(" </Grid.ColumnDefinitions >");
                if(TYPE.ToLower().Contains("string"))
                {
                    code.AppendLine("  <TextBlock   Style=\"{ StaticResource myTextModifyDabaseData}\"   Text=\""+NAME+":\" Grid.Column=\"0\"></TextBlock>");
                   if(NAME.Contains("简介"))
                    {
                        code.AppendLine("   <TextBox Height=\"180\"    Margin=\"50, 0\"  Text=\"{ Binding CurrentPerson." + NAME + ", Mode = TwoWay, UpdateSourceTrigger=PropertyChanged}\" Grid.Column=\"1\"></TextBox>");
                        code.AppendLine(" <Button  Grid.Column=\"1\" Height=\"50\" Width=\"140\" HorizontalAlignment=\"Right\"" +
                            " Foreground=\"Black\"  Content=\"Word导入\"   Margin=\"10, 0, 10, 0\"  Click=\"word导入\"  FontSize=\"25\"    pu:ButtonHelper.ButtonStyle=\"Hollow\"></Button>");
                    }
                   else  if( NAME.Contains("照片"))
                    {
                        code.AppendLine("<StackPanel Orientation=\"Horizontal\" Grid.Column=\"1\">");
                        code.AppendLine("< Button Margin = \"50,5\"  Width = \"120\" Foreground = \"Black\"    Content = \"选择照片\" Tag = \"{Binding CurrentPerson}\" Click=\"Button_Click_所有按钮事件\"></Button>");
                        code.AppendLine(" <Image  Source=\"{ Binding CurrentPerson.Image_Source, Mode = TwoWay, UpdateSourceTrigger = PropertyChanged}\"  Height=\"40\" Width=\"60\"></Image>");
                        code.AppendLine("</StackPanel>");
                    }
                   else if(NAME.Contains("视频"))
                    {
                        code.AppendLine("<StackPanel   Height=\"50\"   Orientation=\"Horizontal\" Grid.Column=\"1\">");
                        code.AppendLine("< Button Margin = \"50,5\"  Width = \"120\" Foreground = \"Black\"    Content = \"选择视频\" Tag = \"{Binding CurrentPerson}\" Click=\"Button_Click_所有按钮事件\"></Button>");
                        code.AppendLine(" <TextBlock  VerticalAlignment=\"Center\" FontSize=\"20\"  Text=\"{ Binding CurrentPerson.视频}\" ></TextBlock>");
                        code.AppendLine("</StackPanel>");
                    }
                   else
                    {
                        code.AppendLine("   <TextBox Height=\"40\" Margin=\"50, 5\"  Text=\"{ Binding CurrentPerson." + NAME + ", Mode = TwoWay, UpdateSourceTrigger=PropertyChanged}\" Grid.Column=\"1\"></TextBox>");
                    }

                }
                if (TYPE.ToLower().Contains("datetime"))
                {
                    code.AppendLine("  <TextBlock   Style=\"{ StaticResource myTextModifyDabaseData}\"   Text=\"" + NAME + ":\" Grid.Column=\"0\"></TextBlock>");
                    code.AppendLine("   <pu:DateTimePicker Height=\"40\"  Margin=\"50, 5\"  pu:SelectedDateTime=\"{ Binding CurrentPerson." + NAME+ ", Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\"    pu:DateTimePickerMode=\"Date\" Grid.Column=\"1\"  FontSize=\"20\"  Foreground=\"#8a8a8a\"></pu:DateTimePicker>");
                }
                rowNum++;
                code.AppendLine(" </Grid>");
            }

             code.AppendLine("<Grid  Grid.Row=\"" + rowNum + "\"  Height=\"80\">");
            code.AppendLine(" <StackPanel Orientation=\"Horizontal\"  HorizontalAlignment=\"Center\">");
            code.AppendLine(" <Button Height=\"50\" Width=\"240\" Foreground=\"Black\"  Content=\"返回\"   Click=\"btn操作数据库_Click\"   FontSize=\"25\"    pu:ButtonHelper.ButtonStyle=\"Hollow\"></Button>");
            code.AppendLine(" <Button Height=\"50\" Width=\"240\" Foreground=\"Black\" Name=\"btn操作数据库\"    Click=\"btn操作数据库_Click\" Content=\"更新\" FontSize=\"25\"    Margin=\"50, 0\"   pu:ButtonHelper.ButtonStyle=\"Hollow\"></Button>");
            code.AppendLine(" </StackPanel>");
            code.AppendLine("</Grid>");
            code.AppendLine("</Grid >");
            code.AppendLine("</ScrollViewer>");
            code.AppendLine("</Grid>");
 
            return code.ToString(); 
        }

        public static string DataBaseXaml(string Name,string SavePath= @"E:\Dahe\_000开发框架\wpfui-backstage\Plugins.ManageCenter\")
        {

            StringBuilder code = new StringBuilder();
            code.Append($" <UserControl x:Class=\"Plugins.ManageCenter.{Name}Control\"\r\n             xml" +
                    "ns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\r\n             xml" +
                    "ns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\r\n              xmlns:li=\"htt" +
                    "p://github.com/zeluisping/loadingIndicators/xaml/controls\"\r\n             xmlns:m" +
                    "c=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" \r\n             x" +
                    "mlns:d=\"http://schemas.microsoft.com/expression/blend/2008\" \r\n             xmlns" +
                    ":local=\"clr-namespace:Plugins.ManageCenter\"\r\n             mc:Ignorable=\"d\" >\r\n  " +
                    "  <UserControl.Resources>\r\n    <ResourceDictionary>\r\n        <ResourceDictionary" +
                    ".MergedDictionaries>\r\n            <ResourceDictionary Source=\"/Plugins.ManageCen" +
                    "ter;component/Themes/Generic.xaml\" />\r\n        </ResourceDictionary.MergedDictio" +
                    "naries>\r\n        <Style TargetType=\"TextBlock\" >\r\n            <Setter Property=\"" +
                    "Foreground\" Value=\"#333\"></Setter>\r\n            <Setter Property=\"FontSize\" Valu" +
                    "e=\"18\"></Setter>\r\n            <Setter Property=\"FontWeight\" Value=\"Bold\"></Sette" +
                    "r>\r\n            <Setter Property=\"FontFamily\" Value=\"微软雅黑\"></Setter>\r\n          " +
                    "  <Setter Property=\"VerticalAlignment\" Value=\"Center\"></Setter>\r\n\r\n            <" +
                    "Setter Property=\"HorizontalAlignment\" Value=\"Right\"></Setter>\r\n            <Sett" +
                    "er Property=\"Margin\" Value=\"0,0,10,0\"></Setter>\r\n            <Setter Property=\"T" +
                    "extAlignment\" Value=\"Right\"></Setter>\r\n        </Style>\r\n        <DataTemplate x" +
                    ":Key=\"ImageListTemplate\">\r\n            <Border   BorderThickness=\"1\" BorderBrush" +
                    "=\"Gray\" Grid.Column=\"2\" Margin=\"5,5,0,0\" CornerRadius=\"5\" Width=\"120\" Height=\"50" +
                    "\">\r\n                <StackPanel Orientation=\"Horizontal\" HorizontalAlignment=\"Ce" +
                    "nter\">\r\n                    <Border  Height=\"45\" Width=\"80\" CornerRadius=\"5\">\r\n " +
                    "                       <Border.Background>\r\n                            <ImageBr" +
                    "ush ImageSource=\"{Binding Image_Source}\" Stretch=\"Uniform\"></ImageBrush>\r\n      " +
                    "                  </Border.Background>\r\n                    </Border>\r\n         " +
                    "           <Button  Height=\"30\" Width=\"30\"  Click=\"删除添加的照片_Click\" Cursor=\"Hand\">" +
                    "\r\n                        <Button.Template>\r\n                            <Contro" +
                    "lTemplate>\r\n                                <Image Source=\"/Plugins.ManageCenter" +
                    ";component/view/img/删除.png\" Stretch=\"Uniform\" />\r\n                            </" +
                    "ControlTemplate>\r\n                        </Button.Template>\r\n                  " +
                    "  </Button>\r\n                </StackPanel>\r\n            </Border>\r\n        </Dat" +
                    "aTemplate>\r\n    </ResourceDictionary>\r\n    </UserControl.Resources>\r\n    <Grid B" +
                    "ackground=\"#F1F1F1\"  >\r\n        <Viewbox Name=\"viewSubject\"  Visibility=\"Visible" +
                    "\" Grid.Row=\"1\">\r\n            <Grid  Height=\"1080\" Width=\"1920\"  >\r\n             " +
                    "   <Grid  Width=\"auto\" Height=\"1080\">\r\n                    <!--#region 管理员模式 -->" +
                    "\r\n                    <Grid  Background=\"#F4F4F4\"  Name=\"grid管理员模式\"  Visibility=" +
                    "\"Visible\">\r\n                        <Grid.RowDefinitions>\r\n                     " +
                    "       <RowDefinition Height=\"60\" ></RowDefinition>\r\n                           " +
                    " <RowDefinition></RowDefinition>\r\n                            <RowDefinition Hei" +
                    "ght=\"120\" ></RowDefinition>\r\n                        </Grid.RowDefinitions>\r\n   " +
                    "                     <StackPanel  HorizontalAlignment=\"Left\" Orientation=\"Horizo" +
                    "ntal\">\r\n                            <Border  Height=\"60\" Background=\"#F1F1F1\"  C" +
                    "ornerRadius=\"30\" Width=\"800\" >\r\n                                <Grid Margin=\"5," +
                    "0,0,0\">\r\n                                    <Grid.ColumnDefinitions>\r\n         " +
                    "                               <ColumnDefinition Width=\"60\"></ColumnDefinition>\r" +
                    "\n                                        <ColumnDefinition Width=\"*\"></ColumnDef" +
                    "inition>\r\n                                        <ColumnDefinition  Width=\"150\"" +
                    "></ColumnDefinition>\r\n                                    </Grid.ColumnDefinitio" +
                    "ns>\r\n                                    <TextBlock  Text=\"\" Grid.Column=\"0\"></T" +
                    "extBlock>\r\n\r\n                                    <Image Source=\"/Plugins.ManageC" +
                    "enter;component/view/img/搜索8a.png\" Height=\"20\"></Image>\r\n                       " +
                    "             <TextBox Grid.Column=\"1\" Tag=\"按姓名查询\"  Name=\"tbName\"   VerticalAlign" +
                    "ment=\"Center\"  FontSize=\"20\" \r\n                                     Height=\"30\" " +
                    "  BorderThickness=\"1\" Margin=\"5\" Background=\"#F1F1F1\"></TextBox>\r\n              " +
                    "                      <StackPanel Orientation=\"Horizontal\" Grid.Column=\"2\" Horiz" +
                    "ontalAlignment=\"Right\" Margin=\"0,0,20,0\">\r\n                                     " +
                    "   <Button Click=\"数据库搜索时删除\" Margin=\"20,0\">\r\n                                    " +
                    "        <Button.Template>\r\n                                                <Cont" +
                    "rolTemplate>\r\n                                                    <Image Source=" +
                    "\"/Plugins.ManageCenter;component/view/img/删除.png\" Height=\"20\"></Image>\r\n        " +
                    "                                        </ControlTemplate>\r\n                    " +
                    "                        </Button.Template>\r\n                                    " +
                    "    </Button>\r\n                                        <Button HorizontalAlignme" +
                    "nt=\"Left\" Width=\"60\" Click=\"数据库搜索\">\r\n                                           " +
                    " <Button.Template>\r\n                                                <ControlTemp" +
                    "late>\r\n                                                    <Image x:Name=\"img\" S" +
                    "ource=\"/Plugins.ManageCenter;component/view/img/搜索.png\" Height=\"30\">\r\n          " +
                    "                                              <Image.Triggers>\r\n                " +
                    "                                            <EventTrigger RoutedEvent=\"Loaded\">\r" +
                    "\n                                                                <BeginStoryboar" +
                    "d>\r\n                                                                    <Storybo" +
                    "ard>\r\n                                                                        <D" +
                    "oubleAnimation Duration=\"0:0:0.5\"  From=\"30\"\r\n                                  " +
                    "                                               To=\"40\" Storyboard.TargetName=\"im" +
                    "g\" Storyboard.TargetProperty=\"Height\"  RepeatBehavior=\"Forever\" AutoReverse=\"Tru" +
                    "e\">\r\n                                                                        </D" +
                    "oubleAnimation>\r\n                                                               " +
                    "     </Storyboard>\r\n                                                            " +
                    "    </BeginStoryboard>\r\n                                                        " +
                    "    </EventTrigger>\r\n                                                        </I" +
                    "mage.Triggers>\r\n                                                    </Image>\r\n  " +
                    "                                              </ControlTemplate>\r\n              " +
                    "                              </Button.Template>\r\n\r\n                            " +
                    "            </Button>\r\n                                    </StackPanel>\r\n      " +
                    "                          </Grid>\r\n                            </Border>\r\n\r\n    " +
                    "                        <Button  Height=\"50\" Width=\"200\" Margin=\"50,0\"  FontSize" +
                    "=\"30\" Content=\"添加数据\"\r\n                             Click=\"新增数据库数据\" Foreground=\"W" +
                    "hite\" ></Button>\r\n                            <!--<Button  Height=\"50\" Width=\"20" +
                    "0\" Margin=\"50,0\"  FontSize=\"30\" Content=\"Excel导入\"\r\n                             " +
                    "Click=\"Excel导入\" Foreground=\"White\" Background=\"{StaticResource NiceBlue}\"></Butt" +
                    "on>-->\r\n                        </StackPanel>\r\n                        <DataGrid" +
                    " Grid.Row=\"1\" \r\n                        Width=\"auto\"  Margin=\"0,0\"\r\n            " +
                    "              AutoGeneratingColumn=\"OnAutoGeneratingColumn\" x:Name=\"myDataGrid\"\r" +
                    "\n                          ItemsSource=\"{Binding CurrentPageList,Mode=TwoWay}\"  " +
                    " BorderBrush=\"LightGray\" BorderThickness=\"1\" CanUserAddRows=\"False\">\r\n          " +
                    "                  <DataGrid.Columns>\r\n                                <DataGridT" +
                    "emplateColumn  >\r\n                                    <DataGridTemplateColumn.He" +
                    "ader  >\r\n                                        <TextBlock VerticalAlignment=\"C" +
                    "enter\" Width=\"150\"   TextAlignment=\"Center\" Text=\"操作\" ></TextBlock>\r\n           " +
                    "                         </DataGridTemplateColumn.Header>\r\n                     " +
                    "               <DataGridTemplateColumn.CellTemplate>\r\n                          " +
                    "              <DataTemplate>\r\n                                            <Stack" +
                    "Panel Orientation=\"Horizontal\" >\r\n                                              " +
                    "  <Button  Height=\"30\" Width=\"60\"   Foreground=\"White\" Content=\"删除\" \r\n          " +
                    "                                       Click=\"btn操作数据库_Click\"    \r\n             " +
                    "                                    ></Button>\r\n                                " +
                    "                <Button  Height=\"30\" Width=\"60\"  Foreground=\"White\"  Content=\"修改" +
                    "\"  \r\n                                                 Click=\"数据库内容修改\" \r\n        " +
                    "                                         Margin=\"20,0\"></Button>\r\n              " +
                    "                              </StackPanel>\r\n                                   " +
                    "     </DataTemplate>\r\n                                    </DataGridTemplateColu" +
                    "mn.CellTemplate>\r\n                                </DataGridTemplateColumn>\r\n   " +
                    "                         </DataGrid.Columns>\r\n                        </DataGrid" +
                    ">\r\n                        <Grid Grid.Row=\"2\">\r\n                            <Gri" +
                    "d.ColumnDefinitions>\r\n                                <ColumnDefinition Width=\"6" +
                    "0\"></ColumnDefinition>\r\n                                <ColumnDefinition></Colu" +
                    "mnDefinition>\r\n                                <ColumnDefinition></ColumnDefinit" +
                    "ion>\r\n                                <ColumnDefinition></ColumnDefinition>\r\n   " +
                    "                             <ColumnDefinition Width=\"60\"></ColumnDefinition>\r\n " +
                    "                           </Grid.ColumnDefinitions>\r\n                          " +
                    "  <Button Grid.Row=\"1\"   Grid.Column=\"1\"  Width=\'250\' Height=\"70\"\r\n\r\n           " +
                    "         Content=\"上一页\"  HorizontalAlignment=\"Center\"\r\n                          " +
                    "   Click=\"上一页\"  Margin=\"50,0,50,0\"  Visibility=\"{Binding 上一页Visibility}\"\r\n      " +
                    "                      Foreground=\"White\"  FontSize=\"35\" ></Button>\r\n            " +
                    "                <TextBlock Grid.Column=\"2\" Width=\"500\" FontSize=\"60\" Foreground=" +
                    "\"#333\"  Visibility=\"{Binding 上一页Visibility}\"    VerticalAlignment=\"Center\" Horiz" +
                    "ontalAlignment=\"Center\"  TextAlignment=\"Center\"><Run Text=\"{Binding PageIndex}\">" +
                    "</Run> / <Run Text=\"{Binding TotalPage}\"></Run></TextBlock>\r\n                   " +
                    "         <Button Grid.Row=\"1\"   Grid.Column=\"3\"  Width=\'250\' Height=\"70\" Content" +
                    "=\"下一页\"  HorizontalAlignment=\"Center\"\r\n\r\n                               Margin=\"5" +
                    "0,0,50,0\" Visibility=\"{Binding 下一页Visibility}\" Click=\"下一页\"\r\n                    " +
                    "        Foreground=\"White\"  FontSize=\"35\" ></Button>\r\n                        </" +
                    "Grid>\r\n\r\n\r\n                    </Grid>\r\n\r\n                    <!--#endregion-->\r" +
                    "\n\r\n                </Grid>\r\n                <Grid Grid.ColumnSpan=\"5\"   Visibili" +
                    "ty=\"Collapsed\"   IsVisibleChanged=\"Grid_IsVisibleChanged\" Name=\"gridLoading\">\r\n " +
                    "                   <Border Background=\"#999\" Opacity=\"0.7\"></Border>\r\n          " +
                    "          <Grid HorizontalAlignment=\"Center\">\r\n                        <StackPan" +
                    "el Margin=\"5\" Orientation=\"Horizontal\">\r\n                            <li:Loading" +
                    "Indicator SpeedRatio=\"1.5\" IsActive=\"{Binding IsArcsActive}\" Mode=\"Arcs\" Name=\"l" +
                    "oading\" ></li:LoadingIndicator>\r\n                            <TextBlock Horizont" +
                    "alAlignment=\"Center\" Margin=\"10,0,0,0\">正在载入资源,请稍候...</TextBlock>\r\n              " +
                    "          </StackPanel>\r\n                    </Grid>\r\n\r\n\r\n\r\n                </Gr" +
                    "id>\r\n            </Grid>\r\n        </Viewbox>\r\n\r\n    </Grid>\r\n</UserControl>\r\n");
            FileHelper.SaveFile_Create(SavePath + Name +
            "Control.xaml", code.ToString());
            return code.ToString();
        }
    }
}
