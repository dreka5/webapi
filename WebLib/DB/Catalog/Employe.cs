using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebLib.DB.Catalog
{
    /// <summary>
    /// Класс сущности работника в бд
    /// </summary>
    public class Employe
    {

        /// <summary>
        /// Id работника
        /// </summary>
        [Key]
        public Int32 EmployeId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SurName { get; set; }
        /// <summary>
        /// отчество
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// День рожднения
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// статус. 1- активен, 2 удалён
        /// </summary>
        public int State { get; set; }

    }
}