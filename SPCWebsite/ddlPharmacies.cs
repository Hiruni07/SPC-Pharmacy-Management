using System;
using System.Data;

namespace SPCWebsite
{
    internal class ddlPharmacies
    {
        public static DataTable DataSource { get; internal set; }
        public static string DataTextField { get; internal set; }
        public static string DataValueField { get; internal set; }
        public static object Items { get; internal set; }
        public static string SelectedValue { get; internal set; }

        internal static void DataBind()
        {
            throw new NotImplementedException();
        }
    }
}