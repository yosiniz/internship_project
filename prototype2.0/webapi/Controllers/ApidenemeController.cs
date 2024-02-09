using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using Microsoft.EntityFrameworkCore;
using HelloMvc.Context;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace webapi.Controllers
{

    [Route("api/deneme")]
    [ApiController]
    //[Authorize(Roles = "admin")]


    public class ApidenemeController : ControllerBase
    {
        // veritabanı baplantısı
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public ApidenemeController(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            this._configuration = configuration;

        }


        [HttpGet]
        // urun goster
        public IEnumerable<urun> Index()
        {   
            return _context.urunler.Include(x => x.kategori).ToList();

        }
        [HttpGet("res/{id}")]
        //public IEnumerable<resim> resim(int id)
        //{
        //    //return _context.resimler.Where(x=>x.urun.Id== id).ToList();

        //}       

        [HttpGet("t/{id}")]
        //urun ekle
        public IEnumerable<urun> Indext(int id)
        {
            return _context.urunler.Where(x => x.Id == id).Include(x => x.kategori).ToList();

        }

        [HttpGet("k")]
        public IEnumerable<urun> Indexk()
        {
            return _context.urunler.Include(x => x.kategori).ToList();
        }
        [HttpGet("h")]
        //kategorileri al
        public IEnumerable<kategori> Indexh()
        {
            return _context.kategoriler;
        }


        //kitap ekleme

        [HttpPost("e")]
        public void ekle(urun kit)
        {
            //resim re = new resim();
            //if (kit.resim != null)
            //{
            //    var uzanti = Path.GetExtension(kit.resim.pic);
            //    var newimagename = Guid.NewGuid() + uzanti;
            //    var konum = Path.Combine(Directory.GetCurrentDirectory());
            //    var stream = new FileStream(konum, FileMode.Create);
            //    kit.resim.pic.CopyTo(stream);

            //}

            var ktg = _context.kategoriler.Where(x => x.Id == kit.kategori.Id).FirstOrDefault();
            kit.kategori = ktg;
            _context.urunler.Add(kit);
            _context.SaveChanges();


        }

        // login ekranı

        [AllowAnonymous]
        [HttpPost("l")]
        public IActionResult login(user us)
        {
            var bilg = _context.users.Include(x => x.rol).Where(i => i.mail == us.mail).FirstOrDefault();
            string hash = sha256.ComputeSha256Hash(us.sifre);
            if (bilg == null)
            {
                //FormsAuthentication.SetAuthCookie(bilg.isim, false);
                return BadRequest("kullanıcı bulunamadı");
            }
            else
            {
                if (bilg.sifre != hash)
                {
                    //FormsAuthentication.SetAuthCookie(bilg.isim, false);
                    return BadRequest("hatalı giriş bilgileri");
                }
                else
                {
                    string token = CreateToken(bilg);
                    return Ok(new { token });
                }

            }
        }

        // jwt token
        private string CreateToken(user us)
        {
            List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Email, us.mail),
            new Claim(ClaimTypes.Role, us.rol.aciklama)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
             claims: claims,
             expires: DateTime.Now.AddHours(1),
             signingCredentials: creds
         );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


        [HttpGet("ur")]
        public IEnumerable<rol> user_rol()
        {
            return _context.roller;
        }

        // kullanıcı ekleme


        [HttpPost("ue")]
        public void user_ekle(user kit)
        {
            string hash = sha256.ComputeSha256Hash(kit.sifre);
            var ktg = _context.roller.Where(x => x.Id == kit.rol.Id).FirstOrDefault();
            kit.rol = ktg;
            kit.sifre = hash;
            _context.users.Add(kit);
            _context.SaveChanges();


        }


        //kullanıcı görüntüleme

        [HttpGet("kug")]
        public IEnumerable<user> kugoruntule()
        {
            return _context.users.Include(x => x.rol).ToList();
        }

        // silme


        [HttpPost("d")]
        public void delete(urun us)
        {
            //user use = _context.users.Where(x => x.Id == us.Id).FirstOrDefault();
            urun use = _context.urunler.Find(us.Id);
            _context.urunler.Remove(use);
            _context.SaveChanges();
        }
        [HttpPost("dk")]
        public void deletek(user us)
        {
            //user use = _context.users.Where(x => x.Id == us.Id).FirstOrDefault();
            user use = _context.users.Find(us.Id);
            _context.users.Remove(use);
            _context.SaveChanges();
        }

        [HttpPost("edt")]
        public void edit(urun urun)
        {
            var edt =_context.urunler.Find(urun.Id);
            edt.CihazAdi = urun.CihazAdi;
            edt.durum = urun.durum;
            edt.resim = urun.resim;
            edt.fiyat= urun.fiyat;
            edt.ozellik = urun.ozellik;
            edt.serino = urun.serino;
            edt.stok= urun.stok;
            var abd=_context.kategoriler.Where(res=>res.Id==urun.kategori.Id).FirstOrDefault();
            edt.kategori= abd;
            _context.SaveChanges();

        }

        [HttpGet("ktg")]
        public IEnumerable<kategori> kategoriler()
        {
            return _context.kategoriler;
        }



        // kategori ekleme

        [HttpPost("ktgek")]
        public void kategoriekle(kategori katgori)
        {
            _context.kategoriler.Add(katgori);
            _context.SaveChanges();

        }

        // kategori edit
        [HttpPost("edtktg")]

        public void edtktg(kategori kategori)
        {
            var edt = _context.kategoriler.Find(kategori.Id);
            edt.kategoriAdi = kategori.kategoriAdi;
            _context.SaveChanges();
        }

        //kategoriyi id ye göre bulma
        [HttpGet("ktgedt/{id}")]

        public IEnumerable<kategori> katedit(int id)
        {
            return _context.kategoriler.Where(x => x.Id == id);
        }



        [HttpPost("dltktg")]

        public void dltktg(kategori kat)
        {
            kategori kategori = _context.kategoriler.Find(kat.Id);
            _context.kategoriler.Remove(kategori);
            _context.SaveChanges();           

        }




        //[HttpGet("t/{id}")]
        ////urun ekle
        //public IEnumerable<urun> Indext(int id)
        //{
        //    return _context.urunler.Where(x => x.Id == id).Include(x => x.kategori).ToList();

        //}


        [HttpGet("h/{mail}")]
        public IEnumerable<user> hesap(string mail)
        {
            return _context.users.Where(x => x.mail == mail).Include(x => x.rol).ToList();
        }



        [HttpGet("kg/{kat}")]
        public IEnumerable<urun> katget(string  kat)
        {
            return _context.urunler.Where(i => i.kategori.kategoriAdi==kat).Include(x=> x.kategori).ToList();
        }













        //[HttpPost("dk")]
        //public void deletek(user us)
        //{
        //    //user use = _context.users.Where(x => x.Id == us.Id).FirstOrDefault();
        //    user use = _context.users.Find(us.Id);
        //    _context.users.Remove(use);
        //    _context.SaveChanges();
        //}





        //[HttpGet("t/{id}")]
        ////urun ekle
        //public IEnumerable<urun> Indext(int id)
        //{
        //    return _context.urunler.Where(x => x.Id == id).Include(x => x.kategori).ToList();

        //}




        //[HttpPost("edt")]
        //public void edit(urun urun)
        //{
        //    var edt = _context.urunler.Find(urun.Id);
        //    edt.CihazAdi = urun.CihazAdi;
        //    edt.durum = urun.durum;
        //    edt.resim = urun.resim;
        //    edt.fiyat = urun.fiyat;
        //    edt.ozellik = urun.ozellik;
        //    edt.serino = urun.serino;
        //    edt.stok = urun.stok;
        //    var abd = _context.kategoriler.Where(res => res.Id == urun.kategori.Id).FirstOrDefault();
        //    edt.kategori = abd;
        //    _context.SaveChanges();

        //}





        //[HttpPost("ue")]
        //public void user_ekle(user kit)
        //{
        //    string hash = sha256.ComputeSha256Hash(kit.sifre);
        //    var ktg = _context.roller.Where(x => x.Id == kit.rol.Id).FirstOrDefault();
        //    kit.rol = ktg;
        //    kit.sifre = hash;
        //    _context.users.Add(kit);
        //    _context.SaveChanges();


        //}

    }
}
