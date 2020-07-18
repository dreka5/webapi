using System;

namespace WebLib
{
#pragma warning disable IDE1006 // Стили именования
    /// <summary>
    /// Когда создаём сущность , то наружу передаём id объекта
    /// </summary>
    public partial class CreatedResultData
    {
        /// <summary>
        /// собсна id
        /// </summary>
        public int createdId { get; set; }
    }
}
