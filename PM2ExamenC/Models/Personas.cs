using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace PM2ExamenC.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(100)]
        public string lactitudes { get; set; }
        [MaxLength(100)]
        public string longitudes { get; set; } = string.Empty;
  
        public string descripciones { get; set; }
        [MaxLength(100)]
        public byte[] foto { get; set; }

    }
}
