using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaesarCipherWebApp.Models
{
    public class CipherViewModel
    {
        [Required(ErrorMessage = "Введите исходный текст!")]
        public string TextIn { get; set; }
        public string TextOut { get; set; }
        [Required(ErrorMessage = "Выберите значение сдвига!")]
        public int Shift { get; set; }
        [Required(ErrorMessage = "Выберите тип действия!")]
        public string ActionType { get; set; }
        public List<CipherAction> Actions { get; set; }
        public CipherViewModel()
        {
           Actions = new List<CipherAction>()
                    {
                        new CipherAction()
                            { ID = 1, Name = "Зашифровать" },
                        new CipherAction()
                            { ID = 2, Name = "Расшифровать" }
                    };
        }
    }
    public class CipherAction
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

}
