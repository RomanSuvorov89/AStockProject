using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class ViewModel
    {

        public int id { get; set; }

        public int uniqId { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Процессор")]
        public string cpu { get; set; }
        public int idsocket { get; set; }

        [Display(Name = "Сокет")]
        public string socket { get; set; }

        public int idbrand { get; set; }

        [Display(Name = "Изготовитель")]
        public string brand { get; set; }

        [Display(Name = "Частота")]
        public int? frequency { get; set; }

        public int idFreq { get; set; }

        [Display(Name = "Тип")]
        public string type { get; set; }

        public int idtype { get; set; }

        [Display(Name = "Ядра")]
        public int core { get; set; }

        [Display(Name = "прочее")]
        public string other { get; set; }
        public int idother { get; set; }

        [Display(Name = "Стоимость")]
        public decimal? price { get; set; }

        [Display(Name = "количество")]
        public int count { get; set; }

        [Display(Name = "количество")]
        public int cap { get; set; }

        [Display(Name = "слот")]
        public string bus { get; set; }

        public int idbus { get; set; }

        public int idDX { get; set; }
        public string API { get; set; }

        public int idPower { get; set; }
        public string Power { get; set; }
        public string Table { get; set; }
        public int? idShop { get; set; }
    }
}