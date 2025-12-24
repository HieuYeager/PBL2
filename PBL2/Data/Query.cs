using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Data
{
    struct SelectFields
    {
        public string[] Field { get; set; }
        public string Table { get; set; }
    }

    public class Query
    {
        private SelectFields SelectField { get; set; }
        private string FromTable { get; set; } = "";
        private string WhereCondition { get; set; } = "";
        private string JoinString { get; set; } = "";
        public Query() { }

        public Query Select(string[] fields, string table)
        {
            this.SelectField = new SelectFields { Field = fields, Table = table };
            string sql = "SELECT ";
            foreach (var field in this.SelectField.Field)
            {
                sql += $" {this.SelectField.Table}.{field}, ";
            }
            return this;
        }

        public Query Select(object obj)
        {
            this.SelectField = new SelectFields { Field = new string[obj.GetType().GetProperties().Count()], Table = obj.GetType().Name };
            int i = 0;
            foreach (var field in obj.GetType().GetProperties())
            {
                this.SelectField.Field[i] = field.Name;
                i++;
            }
            return this;
        }

        public Query From(string table)
        {
            this.FromTable = table;
            return this;
        }

        public Query Where(string condition)
        {
            this.WhereCondition = condition;
            return this;
        }

        public Query Where(object obj)
        {
            foreach (var field in obj.GetType().GetProperties())
            {
                this.WhereCondition += $" {obj.GetType().Name}.{field.Name} = {field.GetValue(obj)} AND ";
            }
            this.WhereCondition = this.WhereCondition.Substring(0, this.WhereCondition.Length - 4);
            return this;
        }

        public Query Join(string table, string joinString)
        {
            this.JoinString = $" JOIN {table} ON {joinString} ";
            return this;
        }

        public string GetSql()
        {
            string sql = "SELECT ";
            foreach (var field in this.SelectField.Field)
            {
                sql += $" {this.SelectField.Table}.{field}, ";
            }
            sql = sql.Substring(0, sql.Length - 2); // Remove last comma
            sql += $" FROM {this.FromTable} ";
            if (this.JoinString != "") { sql += $" {this.JoinString} "; }
            if (this.WhereCondition != "") { sql += $" WHERE {this.WhereCondition}; "; }
            return sql;
        }

        public MySqlDataReader ExecuteToDataReader()
        {
            string sql = this.GetSql();
            return DB.ExecuteReader(sql);
        }

        public DataTable ExecuteToDataTable()
        {
            string sql = this.GetSql();
            return DB.ExecuteQuery(sql);
        }
    }
}
