using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebLib.DB.Catalog
{
    /// <summary>
    /// ����� �������� ��������� � ��
    /// </summary>
    public class Employe
    {

        /// <summary>
        /// Id ���������
        /// </summary>
        [Key]
        public Int32 EmployeId { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public string SurName { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// ���� ���������
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// ������. 1- �������, 2 �����
        /// </summary>
        public int State { get; set; }

    }
}