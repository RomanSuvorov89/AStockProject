using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class ExSystem
    {
        public string[] completed = new string[8];
        public bool[] answers = new bool[19];
        public string _question { get; set; }
        public int thisQuestion { get; set; }
        public int _price { get; set; }
        public void Question(int number)
        {
            string[] questions =   {
                                   "1. Это ваш первый компьютер?",                                         // 0
                                   "2. Вы разбираетесь в компьютерах?",                                    // 1
                                   "3. Вы знакомы с технологическими терминами?(DX12,виртуализация и т.д.)",// 2
                                   "4. Компьютер приобретается на семью?",                                 // 3
                                   "5. Вам знакомы такие слова: Word,Excel,Access?",                       // 4
                                   "6. Вы любите играть в игры?",                                          // 5
                                   "7. Вам знакомы такие игры: DotA 2,Call of Duty, Civilization, WOT?",   // 6
                                   "8. Планируется ли в дальнейшем апгрейд компьютера?",                   // 7
                                   "9. Важен ли вам уровень шума компьютера?",                             // 8
                                   "10.Вам нужен маленький по габаритам ПК?",                              // 9
                                   "11.Будете ли вы заниматься творческой работой на ПК?",                 // 10
                                   "12.Занимаетесь ли монтажом видео?",                                    // 11
                                   "13.Нужна ли вам дискретная аудиокарта?",                               // 12
                                   "14.Планируете ли вы перемещать ПК?",                                   // 13
                                   "15.Нужна ли вам мощная система охлаждения?",                           // 14
                                   "16.Важна ли вам скорость загрузки программ?",                          // 15
                                   "17.Будете ли вы запускать 'тяжелые' приложения?",                      // 16
                                   "18.Вам нужен мощный компьютер?",                                       // 17
                                   "19.Вы собираетесь приобрести ПК на длительное время?"                  // 18
                                    };
            thisQuestion = number;
            _question = questions[number];
          //  return questions[number];
        }

        public void PC(bool[] array, int price)
        {
            //   string[] combo = new string[7];
            _price = price;
            string[] proc =
            {
                "Intel Core i3-2100",
                "AMD PhonomX4 965",
                "Intel Core i5-4570",
                "AMD FX-9590",
                "Intel Core i7-6950X"
            };
            string[] video =
            {
                "nVidia GeForce GT 730",
                "AMD Radeon RX 460",
                "nVidia GeForce GTX 750 Ti",
                "AMD Radeon RX 480",
                "nVidia GeForce GTX1080"

            };
            string[] HDD =
            {
                "HDD 500GB",
                "HDD 2Tb",
                "HDD 500GB + SSD 128GB",
                "HDD 3TB + SSD 128GB",
                "HDD 3TB + SSD 512GB"
            };
            string[] motherboard =
            {
                "GIGABYTE GA-P61",      //i3 
                "MSI 970A-G43",         //amd ph
                "ASUS B85-PLUS",        //intel i5
                "ASUS A88X-PRO",        //amd fx
                "ASUS X99-DELUXE II",   //intel i7
                "ASROCK H170M-ITX/AC ", //microATX Intel(i3)
                "ASUS M5A78L-M LX3"     //microATX AMD(phenom)
            };
            string[] audio =
            {
                "Asus Xonar STX",
                "Titanium HD",
                "ESI Yuli@@@"
            };
            string[] cooling =
            {
                "Стандартное охлаждение(вентиляторы)",
                "Вентиляторы повышенного радиуса",
                "Водяное охлаждение"
            };
            string[] cases =
            {
                "mATX THERMALTAKE Core V21",
                "ATX ACCORD ACC-B305",
                "Zalman Z9 ATX",
                "Zalman Z11 ATX"
            };
            string[] RAM =
            {
                "2GB",
                "4GB",
                "8GB",
                "16GB"
            };

            //БЛОК ВЫБОРА HDD
            if (array[15]) //выбор ССД
            {
                if (array[10])
                {
                    if (array[16])
                    {
                        completed[4] = HDD[4];
                    }
                    else completed[4] = HDD[3];
                }
                else completed[4] = HDD[2];
            }
            if (!array[15])
            {
                if (array[10])
                {
                    completed[4] = HDD[1];
                }
                else completed[4] = HDD[0];
            }

            //БЛОК ВЫБОРА ПРОЦЕССОРА+МП
            if ((array[1]) || (array[5]) || (array[10]))
            {
                if ((array[2]) || (array[3]))
                {
                    if ((array[18]) || (array[19]))
                    {
                        if (price > 100000)
                        {
                            completed[0] = proc[4];
                            completed[1] = motherboard[4];
                        }
                        else
                        {
                            completed[0] = proc[3];
                            completed[1] = motherboard[3];
                        }
                    }
                    else
                    {
                        if ((price > 30000) && (price < 60000))
                        {
                            completed[0] = proc[2];
                            completed[1] = motherboard[2];
                        }
                    }
                }
                else
                {
                    completed[0] = proc[1];
                    completed[1] = motherboard[1];
                }

            }
            if (array[0])
            {
                if (array[9])
                {
                    if (array[17])
                    {
                        completed[0] = proc[0];
                        completed[1] = motherboard[5];
                    }
                    else
                    {
                        completed[0] = proc[1];
                        completed[1] = motherboard[6];
                    }
                }
                else
                {
                    completed[0] = proc[0];
                    completed[1] = motherboard[0];
                }
            }
            if ((!array[0]) && (!array[1]) && (!array[5]))
            {
                if (price > 34000)
                {
                    completed[0] = proc[1];
                    completed[1] = motherboard[1];
                }
                else
                {
                    completed[0] = proc[0];
                    completed[1] = motherboard[0];

                }
            }

            //БЛОК ВЫБОРА ВК
            if (array[3])
            {
                if (array[5])
                {
                    if (array[6])
                    {
                        if (price > 100000)
                            completed[3] = video[4];
                        else completed[3] = video[3];
                    }
                    else completed[3] = video[2];
                }
                else completed[3] = video[1];
            }
            if (!array[3])
            {
                if (array[6])
                {
                    if (price > 50000)
                        completed[3] = video[3];
                    else if (price > 40000)
                        completed[3] = video[2];
                    else if (price > 20000)
                        completed[3] = video[1];
                }
                else completed[3] = video[0];
            }
            //БЛОК выбора Оперативной памяти
            if (price > 40000)
            {
                if (array[7])
                {
                    if ((array[4]) || (array[6]))
                    {
                        if ((array[5]) || (array[11]))
                        {
                            completed[2] = RAM[3];
                        }
                        else completed[2] = RAM[2];
                    }
                    else completed[2] = RAM[0];
                }
                else completed[2] = RAM[1];
            }
            else completed[2] = RAM[0];
            //БЛОК выбора корпуса
            if (array[9])
            {
                if (array[13])
                {
                    completed[5] = cases[0];
                }
                else completed[5] = cases[1];
            }
            else
            {
                if (array[13])
                {
                    completed[5] = cases[2];
                }
                else completed[5] = cases[3];
            }
            //БЛОК выбора аудиокарточки
            if (array[12])
            {
                if (price > 35000)
                {
                    if (price > 50000)
                    {
                        completed[7] = audio[0];
                    }
                    else completed[7] = audio[1];
                }
                else completed[7] = audio[2];
            }
            else completed[7] = "Интегрированное в материнскую плату";
            //БЛОК выбора охлаждения
            if (array[14])
            {
                if (price > 45000)
                {
                    completed[6] = cooling[2];
                }
                else completed[6] = cooling[1];
            }
            else completed[6] = cooling[0];

            //proc,mb,ram,vk,hdd,cases,cooling,audio=8
        }

    }
}
