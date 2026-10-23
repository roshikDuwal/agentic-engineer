using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AgenticEngineer.Persistence.Context
{
    public class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
    {
        public override void SetValue(IDbDataParameter parameter, Guid value)
        {
            parameter.Value = value.ToString();
        }

        public override Guid Parse(object value)
        {
            return Guid.Parse(value.ToString()!);
        }
    }
}
