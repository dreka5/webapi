using System;

namespace WebLib
{
   #pragma warning disable IDE1006 // Стили именования
   public partial class FirmCreateData
   {
       /// <summary>
       /// Название фирмы
       /// </summary>
       public string Name { get; set; }
       /// <summary>
       /// Инн фирмы
       /// </summary>
       public string INN { get; set; }
       /// <summary>
       /// Адрес
       /// </summary>
       public string Address { get; set; }
   }
}
