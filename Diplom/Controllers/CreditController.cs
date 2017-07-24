using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    public class CreditController : Controller
    {
        DiplomEntities1 db = new DiplomEntities1();
        [HttpGet]
        public ActionResult CreditCPU(int idval)
        {
            List < ViewModel > result = new List<ViewModel>();
            if (idval!=0)
            {

                result.Add(new ViewModel { id = 1, uniqId = idval ,
                    Name = db.Cpus.FirstOrDefault(x => x.id == idval).nameCpu,
                    core = db.Cpus.FirstOrDefault(x => x.id == idval).coresCpu.GetValueOrDefault(),
                    price = db.Cpus.FirstOrDefault(x => x.id == idval).Price,
                    count = db.Cpus.FirstOrDefault(x => x.id == idval).Count.GetValueOrDefault(),
                    idbrand = db.Cpus.FirstOrDefault(x => x.id == idval).idManufacture.GetValueOrDefault(),
                    idsocket = db.Cpus.FirstOrDefault(x => x.id == idval).socketCpu.GetValueOrDefault()
                });
            }
            else
            {
                result.Add(new ViewModel { id = 1, uniqId = idval, Name = null, core = 0, price = 0, count = 0 });
            }

            foreach (var data in db.Manufacturers)
            {
                result.Add(new ViewModel { brand = data.Manufacture, id = data.id });
            }

            foreach (var data in db.Sockets)
            {
                result.Add(new ViewModel { socket = data.socket, id = data.id });

            }
            return PartialView(result);
        }

        [HttpPost]
        public void CreditCPU(FormCollection frm)
        {
            int idcpu = Convert.ToInt32(frm.Get("idCpu"));
            int idM = Convert.ToInt32(frm.Get("idManufacture"));
            int idS = Convert.ToInt32(frm.Get("socketid"));
            int core = Convert.ToInt32(frm.Get("cores"));
            decimal? price = Convert.ToDecimal(frm.Get("price"));
            int count = Convert.ToInt32(frm.Get("count"));
            if (idcpu == 0)
            {
                for (int i = 1; i < 999999; i++)
                {
                    if (!(db.Cpus.Any(x => x.id == i)))
                    {
                        idcpu = i;
                        break;
                    }
                }
                Cpus cpu = new Cpus();
                cpu.id = idcpu;
                cpu.nameCpu = frm.Get("nameCpu");
                cpu.coresCpu = core;
                cpu.Price = price;
                cpu.Count = count;
                cpu.idManufacture = idM;
                cpu.socketCpu = idS;
                db.Cpus.Add(cpu);
            }
            else
            {
                db.Cpus.FirstOrDefault(x => x.id == idcpu).nameCpu = frm.Get("nameCpu");
                db.Cpus.FirstOrDefault(x => x.id == idcpu).coresCpu = core;
                db.Cpus.FirstOrDefault(x => x.id == idcpu).Price = price;
                db.Cpus.FirstOrDefault(x => x.id == idcpu).Count = count;
                db.Cpus.FirstOrDefault(x => x.id == idcpu).idManufacture = idM;
                db.Cpus.FirstOrDefault(x => x.id == idcpu).socketCpu = idS;
            }
            db.SaveChanges();
        }

        [HttpGet]
        public ActionResult CreditMB(int idval)
        {
            List<ViewModel> result = new List<ViewModel>();
            if (idval != 0)
            {

                result.Add(new ViewModel
                {
                    id = 1,
                    uniqId = idval,
                    Name = db.MotherBoards.FirstOrDefault(x => x.id == idval).nameMB,
                    idtype = db.MotherBoards.FirstOrDefault(x => x.id == idval).RamType.id,
                    price = db.MotherBoards.FirstOrDefault(x => x.id == idval).Price,
                    count = db.MotherBoards.FirstOrDefault(x => x.id == idval).Count.GetValueOrDefault(),
                    idother = db.MotherBoards.FirstOrDefault(x=> x.id == idval).FormFactorMB.id,
                    idbus = db.MotherBoards.FirstOrDefault(x=> x.id == idval).slotBus.id,
                    idbrand = db.MotherBoards.FirstOrDefault(x => x.id == idval).idManufacture.GetValueOrDefault(),
                    idsocket = db.MotherBoards.FirstOrDefault(x => x.id == idval).Sockets.id
                });
            }
            else
            {
                result.Add(new ViewModel { id = 1, uniqId = idval });
            }

            foreach (var data in db.Manufacturers)
            {
                result.Add(new ViewModel { brand = data.Manufacture, id = data.id });
            }

            foreach (var data in db.Sockets)
            {
                result.Add(new ViewModel { socket = data.socket, id = data.id });

            }
            foreach (var data in db.slotBus)
            {
                result.Add(new ViewModel { bus = data.typeBus, id = data.id });
            }
            foreach(var data in db.RamType)
            {
                result.Add(new ViewModel { type = data.typeMemory, id = data.id });
            }
            foreach (var data in db.FormFactorMB)
            {
                result.Add(new ViewModel { other=data.nameFF, id = data.id });
            }
            return PartialView(result);
        }


        [HttpPost]
        public void CreditMB(FormCollection frm)
        {
            int idMB = Convert.ToInt32(frm.Get("idMB"));
            int idM = Convert.ToInt32(frm.Get("idManufacture"));
            int idS = Convert.ToInt32(frm.Get("socketid"));
            int idR = Convert.ToInt32(frm.Get("idRam"));
            int idF = Convert.ToInt32(frm.Get("idFF"));
            int idB = Convert.ToInt32(frm.Get("idBus")); 
            decimal? price = Convert.ToDecimal(frm.Get("price"));
            int count = Convert.ToInt32(frm.Get("count"));
            if (idMB == 0)
            {
                for (int i = 1; i < 999999; i++)
                {
                    if (!(db.MotherBoards.Any(x => x.id == i)))
                    {
                        idMB = i;
                        break;
                    }
                }
                MotherBoards MB = new MotherBoards();
                MB.id = idMB;
                MB.nameMB = frm.Get("nameMB");
                MB.FFMB = idF;
                MB.typeRam = idR;
                MB.slotsBus = idB;
                MB.idManufacture = idM;
                MB.socketMB = idS;
                MB.Price = price;
                MB.Count = count;
                db.MotherBoards.Add(MB);
            }
            else
            {
                db.MotherBoards.FirstOrDefault(x => x.id == idMB).nameMB = frm.Get("nameMB");
                db.MotherBoards.FirstOrDefault(x => x.id == idMB).FFMB = idF;
                db.MotherBoards.FirstOrDefault(x => x.id == idMB).typeRam = idR;
                db.MotherBoards.FirstOrDefault(x => x.id == idMB).slotsBus = idB;
                db.MotherBoards.FirstOrDefault(x => x.id == idMB).Price = price;
                db.MotherBoards.FirstOrDefault(x => x.id == idMB).Count = count;
                db.MotherBoards.FirstOrDefault(x => x.id == idMB).idManufacture = idM;
                db.MotherBoards.FirstOrDefault(x => x.id == idMB).socketMB = idS;
            }
            db.SaveChanges();
        }

        [HttpGet]
        public ActionResult CreditRAM(int idval)
        {
            List<ViewModel> result = new List<ViewModel>();
            if (idval != 0)
            {

                result.Add(new ViewModel
                {
                    id = 1,
                    uniqId = idval,
                    Name = db.Rams.FirstOrDefault(x => x.id == idval).nameRam,
                    idFreq = db.Rams.FirstOrDefault(x => x.id == idval).typeRam.GetValueOrDefault(),
                    idtype = db.Rams.FirstOrDefault(x => x.id == idval).RamType.id,
                    price = db.Rams.FirstOrDefault(x => x.id == idval).Price,
                    count = db.Rams.FirstOrDefault(x => x.id == idval).Count.GetValueOrDefault(),
                    idbrand = db.Rams.FirstOrDefault(x => x.id == idval).idManufacture.GetValueOrDefault(),
                    cap = db.Rams.FirstOrDefault(x => x.id == idval).capRam.GetValueOrDefault()
                });
            }
            else
            {
                result.Add(new ViewModel { id = 1, uniqId = idval });
            }

            foreach (var data in db.RamType)
            {
                result.Add(new ViewModel { type = data.typeMemory, id = data.id });
            }

            foreach (var data in db.partsFreq)
            {
                result.Add(new ViewModel { frequency = data.frequency , id = data.id });

            }
            foreach (var data in db.Manufacturers)
            {
                result.Add(new ViewModel { brand = data.Manufacture, id = data.id });
            }
            return PartialView(result);
        }

        [HttpPost]
        public void CreditRAM(FormCollection frm)
        {
            int idRam = Convert.ToInt32(frm.Get("idRAM"));
            int idM = Convert.ToInt32(frm.Get("idManufacture"));
            int idR = Convert.ToInt32(frm.Get("idRamType"));
            int idF = Convert.ToInt32(frm.Get("idFreq"));
            decimal? price = Convert.ToDecimal(frm.Get("price"));
            int count = Convert.ToInt32(frm.Get("count"));
            int cap = Convert.ToInt32(frm.Get("cap"));
            if (idRam == 0)
            {
                for (int i = 1; i < 999999; i++)
                {
                    if (!(db.Rams.Any(x => x.id == i)))
                    {
                        idRam = i;
                        break;
                    }
                }
                Rams ram = new Rams();
                ram.id = idRam;
                ram.nameRam = frm.Get("nameRam");
                ram.Price = price;
                ram.Count = count;
                ram.idManufacture = idM;
                ram.typeRam = idR;
                ram.freqRam = idF;
                ram.capRam = cap;
                db.Rams.Add(ram);
            }
            else
            {
                db.Rams.FirstOrDefault(x => x.id == idRam).nameRam = frm.Get("nameRam");
                db.Rams.FirstOrDefault(x => x.id == idRam).Price = price;
                db.Rams.FirstOrDefault(x => x.id == idRam).Count = count;
                db.Rams.FirstOrDefault(x => x.id == idRam).idManufacture = idM;
                db.Rams.FirstOrDefault(x => x.id == idRam).typeRam = idR;
                db.Rams.FirstOrDefault(x => x.id == idRam).freqRam = idF;
                db.Rams.FirstOrDefault(x => x.id == idRam).capRam = cap;
            }
            db.SaveChanges();
        }


        [HttpGet]
        public ActionResult CreditVideo(int idval)
        {
            List<ViewModel> result = new List<ViewModel>();
            if (idval != 0)
            {

                result.Add(new ViewModel
                {
                    id = 1,
                    uniqId = idval,
                    Name = db.VideoCards.FirstOrDefault(x => x.id == idval).NameVideo,
                    idtype = db.VideoCards.FirstOrDefault(x => x.id == idval).TypeMem.GetValueOrDefault(),
                    price = db.VideoCards.FirstOrDefault(x => x.id == idval).Price,
                    count = db.VideoCards.FirstOrDefault(x => x.id == idval).Count.GetValueOrDefault(),
                    idbrand = db.VideoCards.FirstOrDefault(x => x.id == idval).idManufacture.GetValueOrDefault(),
                    idbus = db.VideoCards.FirstOrDefault(x => x.id == idval).Bus.GetValueOrDefault(),
                    idDX = db.VideoCards.FirstOrDefault(x => x.id == idval).DirectX.GetValueOrDefault()
                });
            }
            else
            {
                result.Add(new ViewModel { id = 1, uniqId = idval });
            }

            foreach (var data in db.RamType)
            {
                result.Add(new ViewModel { type = data.typeMemory, id = data.id });
            }

            foreach (var data in db.slotBus)
            {
                result.Add(new ViewModel { bus = data.typeBus, id = data.id });

            }
            foreach (var data in db.Manufacturers)
            {
                result.Add(new ViewModel { brand = data.Manufacture, id = data.id });
            }
            foreach (var data in db.APIs)
            {
                result.Add(new ViewModel { API = data.nameAPI, id = data.id });
            }
            return PartialView(result);
        }

        [HttpPost]
        public void CreditVideo(FormCollection frm)
        {
            int idVideo = Convert.ToInt32(frm.Get("idVideo"));
            int idM = Convert.ToInt32(frm.Get("idManufacture"));
            int idR = Convert.ToInt32(frm.Get("idRamType"));
            int idB = Convert.ToInt32(frm.Get("idBus"));
            int idA = Convert.ToInt32(frm.Get("idApi"));
            decimal? price = Convert.ToDecimal(frm.Get("price"));
            int count = Convert.ToInt32(frm.Get("count"));
            if (idVideo == 0)
            {
                for (int i = 1; i < 999999; i++)
                {
                    if (!(db.VideoCards.Any(x => x.id == i)))
                    {
                        idVideo = i;
                        break;
                    }
                }
                VideoCards VC = new VideoCards();
                VC.id = idVideo;
                VC.NameVideo = frm.Get("nameVideo");
                VC.Price = price;
                VC.Count = count;
                VC.idManufacture = idM;
                VC.TypeMem = idR;
                VC.DirectX = idA;
                VC.Bus = idB;

                db.VideoCards.Add(VC);
            }
            else
            {
                db.VideoCards.FirstOrDefault(x => x.id == idVideo).NameVideo = frm.Get("nameVideo");
                db.VideoCards.FirstOrDefault(x => x.id == idVideo).Price = price;
                db.VideoCards.FirstOrDefault(x => x.id == idVideo).Count = count;
                db.VideoCards.FirstOrDefault(x => x.id == idVideo).idManufacture = idM;
                db.VideoCards.FirstOrDefault(x => x.id == idVideo).TypeMem = idR;
                db.VideoCards.FirstOrDefault(x => x.id == idVideo).DirectX = idA;
                db.VideoCards.FirstOrDefault(x => x.id == idVideo).Bus = idB;

            }
            db.SaveChanges();
        }


        [HttpGet]
        public ActionResult CreditBox(int idval)
        {
            List<ViewModel> result = new List<ViewModel>();
            if (idval != 0)
            {

                result.Add(new ViewModel
                {
                    id = 1,
                    uniqId = idval,
                    Name = db.Boxes.FirstOrDefault(x => x.id == idval).nameBox,
                    price = db.Boxes.FirstOrDefault(x => x.id == idval).Price,
                    count = db.Boxes.FirstOrDefault(x => x.id == idval).Count.GetValueOrDefault(),
                    idbrand = db.Boxes.FirstOrDefault(x => x.id == idval).idManufacture.GetValueOrDefault(),
                    idPower = db.Boxes.FirstOrDefault(x => x.id == idval).Power.GetValueOrDefault(),
                    idtype = db.Boxes.FirstOrDefault(x => x.id == idval).idForm.GetValueOrDefault(),
                });
            }
            else
            {
                result.Add(new ViewModel { id = 1, uniqId = idval });
            }

            foreach (var data in db.FormFactorMB)
            {
                result.Add(new ViewModel { type = data.nameFF, id = data.id });
            }

            foreach (var data in db.Powers)
            {
                result.Add(new ViewModel { Power = data.NameBox, cap=data.Watts.GetValueOrDefault(), id = data.id });

            }
            foreach (var data in db.Manufacturers)
            {
                result.Add(new ViewModel { brand = data.Manufacture, id = data.id });
            }

            return PartialView(result);
        }

        [HttpPost]
        public void CreditBox(FormCollection frm)
        {
            int idBox = Convert.ToInt32(frm.Get("idBox"));
            int idM = Convert.ToInt32(frm.Get("idManufacture"));
            int idF = Convert.ToInt32(frm.Get("idFF"));
            int idP = Convert.ToInt32(frm.Get("idPower"));
            decimal? price = Convert.ToDecimal(frm.Get("price"));
            int count = Convert.ToInt32(frm.Get("count"));
            if (idBox == 0)
            {
                for (int i = 1; i < 999999; i++)
                {
                    if (!(db.Boxes.Any(x => x.id == i)))
                    {
                        idBox = i;
                        break;
                    }
                }
                Boxes box = new Boxes();
                box.id = idBox;
                box.nameBox = frm.Get("nameBox");
                box.Price = price;
                box.Count = count;
                box.idManufacture = idM;
                box.idForm = idF;
                box.Power = idP;

                db.Boxes.Add(box);
            }
            else
            {
                db.Boxes.FirstOrDefault(x => x.id == idBox).nameBox = frm.Get("nameBox");
                db.Boxes.FirstOrDefault(x => x.id == idBox).Price = price;
                db.Boxes.FirstOrDefault(x => x.id == idBox).Count = count;
                db.Boxes.FirstOrDefault(x => x.id == idBox).idManufacture = idM;
                db.Boxes.FirstOrDefault(x => x.id == idBox).idForm = idF;
                db.Boxes.FirstOrDefault(x => x.id == idBox).Power = idP;

            }
            db.SaveChanges();
        }


        [HttpGet]
        public ActionResult CreditAudio(int idval)
        {
            List<ViewModel> result = new List<ViewModel>();
            if (idval != 0)
            {

                result.Add(new ViewModel
                {
                    id = 1,
                    uniqId = idval,
                    Name = db.AudioCards.FirstOrDefault(x => x.id == idval).NameAudio,
                    price = db.AudioCards.FirstOrDefault(x => x.id == idval).Price,
                    count = db.AudioCards.FirstOrDefault(x => x.id == idval).Count.GetValueOrDefault(),
                    idbrand = db.AudioCards.FirstOrDefault(x => x.id == idval).idManufacture.GetValueOrDefault(),
                    idbus = db.AudioCards.FirstOrDefault(x => x.id == idval).Bus.GetValueOrDefault()
                });
            }
            else
            {
                result.Add(new ViewModel { id = 1, uniqId = idval });
            }

            foreach (var data in db.slotBus)
            {
                result.Add(new ViewModel { bus = data.typeBus,  id = data.id });

            }
            foreach (var data in db.Manufacturers)
            {
                result.Add(new ViewModel { brand = data.Manufacture, id = data.id });
            }

            return PartialView(result);
        }

        [HttpPost]
        public void CreditAudio(FormCollection frm)
        {
            int idAudio = Convert.ToInt32(frm.Get("idAudio"));
            int idM = Convert.ToInt32(frm.Get("idManufacture"));
            int idB = Convert.ToInt32(frm.Get("idBus"));
            decimal? price = Convert.ToDecimal(frm.Get("price"));
            int count = Convert.ToInt32(frm.Get("count"));
            if (idAudio == 0)
            {
                for (int i = 1; i < 999999; i++)
                {
                    if (!(db.AudioCards.Any(x => x.id == i)))
                    {
                        idAudio = i;
                        break;
                    }
                }
                AudioCards AC = new AudioCards();
                AC.id = idAudio;
                AC.NameAudio = frm.Get("nameAudio");
                AC.Price = price;
                AC.Count = count;
                AC.idManufacture = idM;
                AC.Bus = idB;

                db.AudioCards.Add(AC);
            }
            else
            {
                db.AudioCards.FirstOrDefault(x => x.id == idAudio).NameAudio = frm.Get("nameAudio");
                db.AudioCards.FirstOrDefault(x => x.id == idAudio).Price = price;
                db.AudioCards.FirstOrDefault(x => x.id == idAudio).Count = count;
                db.AudioCards.FirstOrDefault(x => x.id == idAudio).idManufacture = idM;
                db.AudioCards.FirstOrDefault(x => x.id == idAudio).Bus = idB;

            }
            db.SaveChanges();
        }


        [HttpGet]
        public ActionResult CreditHDD(int idval)
        {
            List<ViewModel> result = new List<ViewModel>();
            if (idval != 0)
            {

                result.Add(new ViewModel
                {
                    id = 1,
                    uniqId = idval,
                    Name = db.HDDs.FirstOrDefault(x => x.id == idval).nameHDD,
                    price = db.HDDs.FirstOrDefault(x => x.id == idval).Price,
                    count = db.HDDs.FirstOrDefault(x => x.id == idval).Count.GetValueOrDefault(),
                    idbrand = db.HDDs.FirstOrDefault(x => x.id == idval).idManufacture.GetValueOrDefault(),
                    idtype = db.HDDs.FirstOrDefault(x => x.id == idval).typeHDD.GetValueOrDefault(),
                    cap = db.HDDs.FirstOrDefault(x => x.id == idval).capatity.GetValueOrDefault(),
                });
            }
            else
            {
                result.Add(new ViewModel { id = 1, uniqId = idval });
            }

            foreach (var data in db.HDDType)
            {
                result.Add(new ViewModel { type = data.Type, id = data.id });

            }
            foreach (var data in db.Manufacturers)
            {
                result.Add(new ViewModel { brand = data.Manufacture, id = data.id });
            }

            return PartialView(result);
        }

        [HttpPost]
        public void CreditHDD(FormCollection frm)
        {
            int idHDD = Convert.ToInt32(frm.Get("idHDD"));
            int idM = Convert.ToInt32(frm.Get("idManufacture"));
            int idR = Convert.ToInt32(frm.Get("idRam"));
            decimal? price = Convert.ToDecimal(frm.Get("price"));
            int count = Convert.ToInt32(frm.Get("count"));
            int cap = Convert.ToInt32(frm.Get("cap"));
            if (idHDD == 0)
            {
                for (int i = 1; i < 999999; i++)
                {
                    if (!(db.HDDs.Any(x => x.id == i)))
                    {
                        idHDD = i;
                        break;
                    }
                }
                HDDs hdd = new HDDs();
                hdd.id = idHDD;
                hdd.nameHDD = frm.Get("nameHDD");
                hdd.Price = price;
                hdd.Count = count;
                hdd.idManufacture = idM;
                hdd.typeHDD = idR;
                hdd.capatity = cap;

                db.HDDs.Add(hdd);
            }
            else
            {
                db.HDDs.FirstOrDefault(x => x.id == idHDD).nameHDD = frm.Get("nameHDD");
                db.HDDs.FirstOrDefault(x => x.id == idHDD).Price = price;
                db.HDDs.FirstOrDefault(x => x.id == idHDD).Count = count;
                db.HDDs.FirstOrDefault(x => x.id == idHDD).idManufacture = idM;
                db.HDDs.FirstOrDefault(x => x.id == idHDD).typeHDD = idR;
                db.HDDs.FirstOrDefault(x => x.id == idHDD).capatity = cap;

            }
            db.SaveChanges();
        }



        [HttpGet]
        public ActionResult CreditPower(int idval)
        {
            List<ViewModel> result = new List<ViewModel>();
            if (idval != 0)
            {

                result.Add(new ViewModel
                {
                    id = 1,
                    uniqId = idval,
                    Name = db.Powers.FirstOrDefault(x => x.id == idval).NameBox,
                    price = db.Powers.FirstOrDefault(x => x.id == idval).Price,
                    count = db.Powers.FirstOrDefault(x => x.id == idval).Count.GetValueOrDefault(),
                    idbrand = db.Powers.FirstOrDefault(x => x.id == idval).idManufacture.GetValueOrDefault(),
                    cap = db.Powers.FirstOrDefault(x => x.id == idval).Watts.GetValueOrDefault()
                });
            }
            else
            {
                result.Add(new ViewModel { id = 1, uniqId = idval });
            }

            foreach (var data in db.Manufacturers)
            {
                result.Add(new ViewModel { brand = data.Manufacture, id = data.id });
            }

            return PartialView(result);
        }

        [HttpPost]
        public void CreditPower(FormCollection frm)
        {
            int idPower = Convert.ToInt32(frm.Get("idPower"));
            int idM = Convert.ToInt32(frm.Get("idManufacture"));
            decimal? price = Convert.ToDecimal(frm.Get("price"));
            int count = Convert.ToInt32(frm.Get("count"));
            int cap = Convert.ToInt32(frm.Get("cap"));
            if (idPower == 0)
            {
                for (int i = 1; i < 999999; i++)
                {
                    if (!(db.Powers.Any(x => x.id == i)))
                    {
                        idPower = i;
                        break;
                    }
                }
                Powers pow = new Powers();
                pow.id = idPower;
                pow.NameBox = frm.Get("namePower");
                pow.Price = price;
                pow.Count = count;
                pow.idManufacture = idM;
                pow.Watts = cap;

                db.Powers.Add(pow);
            }
            else
            {
                db.Powers.FirstOrDefault(x => x.id == idPower).NameBox = frm.Get("namePower");
                db.Powers.FirstOrDefault(x => x.id == idPower).Price = price;
                db.Powers.FirstOrDefault(x => x.id == idPower).Count = count;
                db.Powers.FirstOrDefault(x => x.id == idPower).idManufacture = idM;
                db.Powers.FirstOrDefault(x => x.id == idPower).Watts = cap;

            }
            db.SaveChanges();
        }


        [HttpPost]
        public void Delete(int id,string table)
        {
            if (table=="CPU")
            {
                var item = db.Cpus.Single(p => p.id == id);
                db.Cpus.Remove(item);
            }
            if (table == "MB")
            {
                var item = db.MotherBoards.Single(p => p.id == id);
                db.MotherBoards.Remove(item);
            }
            if (table == "RAM")
            {
                var item = db.Rams.Single(p => p.id == id);
                db.Rams.Remove(item);
            }
            if (table == "Video")
            {
                var item = db.VideoCards.Single(p => p.id == id);
                db.VideoCards.Remove(item);
            }
            if (table == "Box")
            {
                var item = db.Boxes.Single(p => p.id == id);
                db.Boxes.Remove(item);
            }
            if (table == "Audio")
            {
                var item = db.AudioCards.Single(p => p.id == id);
                db.AudioCards.Remove(item);
            }
            if (table == "HDD")
            {
                var item = db.HDDs.Single(p => p.id == id);
                db.HDDs.Remove(item);
            }
            if (table == "Power")
            {
                var item = db.Powers.Single(p => p.id == id);
                db.Powers.Remove(item);
            }
            db.SaveChanges();
        }

        [HttpGet]
        public ActionResult CreditOrderM(int id, string table , string namePart , string nameBrand,decimal price)
        {
            ViewModel result = new ViewModel();
            result.uniqId = id;
            result.Table = table;
            result.Name = namePart;
            result.brand = nameBrand;
            result.price = price;
            return PartialView(result);
        }

        [HttpPost]
        public void CreditOrderM(int id, string table, string nameP, string nameB, int count, decimal price)
        {
            OrdersM OM = new OrdersM();
            var item = db.Manufacturers.Single(p => p.Manufacture == nameB);
            OM.idManufacture = item.id;
            OM.numberParts = count;
            OM.DateOrder = DateTime.Now;
            OM.namePart = nameP;
            OM.Status = true;
            OM.nameTable = table;
            OM.Manager = User.Identity.Name;
            OM.Price = price;
            db.OrdersM.Add(OM);
            db.SaveChanges();
        }
        [HttpPost]
        public void CompleteOrderM(int id,string nameP,int count,string table)
        {
            OrdersM OM = new OrdersM();
            if (table == "CPU")
            {
                db.Cpus.Single(p => p.nameCpu == nameP).Count += count;
            }
            if (table == "MB")
            {
                db.MotherBoards.Single(p => p.nameMB == nameP).Count += count;
            }
            if (table == "Audio")
            {
                db.AudioCards.Single(p => p.NameAudio == nameP).Count += count;
            }
            if (table == "Video")
            {
                db.VideoCards.Single(p => p.NameVideo == nameP).Count += count;
            }
            if (table == "Box")
            {
                db.Boxes.Single(p => p.nameBox == nameP).Count += count;
            }
            if (table == "Power")
            {
                db.Powers.Single(p => p.NameBox == nameP).Count += count;
            }
            if (table == "HDD")
            {
                db.HDDs.Single(p => p.nameHDD == nameP).Count += count;
            }
            if (table == "RAM")
            {
                db.Rams.Single(p => p.nameRam == nameP).Count += count;
            }
            db.OrdersM.FirstOrDefault(x => x.idOrder == id).Status = false;
            db.OrdersM.FirstOrDefault(x => x.idOrder == id).DateComplete = DateTime.Now;
            db.SaveChanges();
        }
        [HttpGet]
        public ActionResult CreditOrderS(int id, string table, string namePart, string nameBrand, decimal price, int count)
        {
            List<ViewModel> result = new List<ViewModel>();
            result.Add(new ViewModel { uniqId = id, Table = table, Name = namePart, brand = nameBrand, price = price, cap = count});
            foreach (var data in db.Shops)
            {
                result.Add(new ViewModel { Name = data.nameShop, idShop = data.idShop });
            }
            return PartialView(result);
        }

        [HttpPost]
        public void CreditOrderS(int id, string table, string nameP, string nameB, int count, decimal price, int idShop)
        {
            OrderS OS = new OrderS();
            var item = db.Shops.Single(p => p.idShop == idShop);
            OS.idShop = item.idShop;
            OS.numberParts = count;
            OS.DateOrder = DateTime.Now;
            OS.namePart = nameP;
            OS.Status = true;
            OS.nameTable = table;
            OS.Manager = User.Identity.Name;
            OS.Price = price;
            db.OrderS.Add(OS);
            db.SaveChanges();
        }
        [HttpPost]
        public void CompleteOrderS(int id, string nameP, int count, string table)
        {
            OrdersM OM = new OrdersM();
            if (table == "CPU")
            {
                db.Cpus.Single(p => p.nameCpu == nameP).Count -= count;
            }
            if (table == "MB")
            {
                db.MotherBoards.Single(p => p.nameMB == nameP).Count -= count;
            }
            if (table == "Audio")
            {
                db.AudioCards.Single(p => p.NameAudio == nameP).Count -= count;
            }
            if (table == "Video")
            {
                db.VideoCards.Single(p => p.NameVideo == nameP).Count -= count;
            }
            if (table == "Box")
            {
                db.Boxes.Single(p => p.nameBox == nameP).Count -= count;
            }
            if (table == "Power")
            {
                db.Powers.Single(p => p.NameBox == nameP).Count -= count;
            }
            if (table == "HDD")
            {
                db.HDDs.Single(p => p.nameHDD == nameP).Count -= count;
            }
            if (table == "RAM")
            {
                db.Rams.Single(p => p.nameRam == nameP).Count -= count;
            }
            db.OrderS.FirstOrDefault(x => x.idOrder == id).Status = false;
            db.OrderS.FirstOrDefault(x => x.idOrder == id).DateComplete = DateTime.Now;
            db.SaveChanges();
        }
    }
}