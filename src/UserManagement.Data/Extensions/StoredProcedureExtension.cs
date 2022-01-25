namespace UserManagement.Data.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    public static class StoredProcedureExtension
    {
        public static async Task<List<T>> ExecuteSPAsync<T>(this DbSet<T> entity, string StoreProcedureName, CancellationToken cancellationToken, List<SPParameter> parameters = null) where T : class
        {
            StringBuilder parameterString = new();
            List<SqlParameter> sqlParameters = new();

            if (parameters != null)
            {
                foreach (SPParameter parameter in parameters)
                {
                    if (parameterString.Length > 0)
                        parameterString.Append(',');

                    parameterString.Append($" {parameter.Name}");

                    sqlParameters.Add(new SqlParameter(parameter.Name, parameter.Value)
                    {
                        Direction = ParameterDirection.Input,
                        SqlDbType = GetSqlDbTypeFromTypeCode(parameter.Type)
                    });
                }
            }
            return (await entity.FromSqlRaw($"{StoreProcedureName} {parameterString}", sqlParameters.ToArray()).ToListAsync(cancellationToken));
        }

        private static SqlDbType GetSqlDbTypeFromTypeCode(TypeCode typeCode)
        {
            return typeCode switch
            {
                TypeCode.Boolean => SqlDbType.Bit,
                TypeCode.Int16 => SqlDbType.SmallInt,
                TypeCode.Int32 => SqlDbType.Int,
                TypeCode.Int64 => SqlDbType.BigInt,
                TypeCode.Double => SqlDbType.Float,
                TypeCode.Decimal => SqlDbType.Decimal,
                TypeCode.DateTime => SqlDbType.DateTime,
                TypeCode.String => SqlDbType.VarChar,
                _ => SqlDbType.VarChar,
            };
        }
    }

    public class SPParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public TypeCode Type { get; set; }
    }
}
