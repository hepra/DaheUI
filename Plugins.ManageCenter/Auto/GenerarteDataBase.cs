using System;
using System.Collections.Generic;
using System.Linq;
 using System.Reflection;
 using System.Text;
 using System.Threading.Tasks;
 using UIFrameworkCore.Settings;
namespace Plugins.ManageCenter.Auto
 {
  public static class GenerarteDataBase
 {
  public static void GenerateDataBase()
    {
UIFrameworkCore.Helper.SqliteHelper.CreateTable<UIFrameworkCore.Model.DataBase.PersonInfo>();
UIFrameworkCore.Helper.SqliteHelper.CreateTable<UIFrameworkCore.Model.DataBase.ModelBaseForDB>();
    }
    }
    }
