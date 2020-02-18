using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3RestfulApi.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 公司简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public ICollection<Employee> Employee { get;set;}
}


}
