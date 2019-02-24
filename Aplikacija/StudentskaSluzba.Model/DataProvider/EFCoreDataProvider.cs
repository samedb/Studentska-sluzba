using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;

namespace StudentskaSluzba.Model.Models
{

    public class EFCoreDataProvider : IDataProvider
    {
        #region Login
        public async Task<Korisnik> LoginIspravan(string username, string password)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var rez = await context.Korisnik.FirstOrDefaultAsync(k => k.Username == username && k.Password == Enkripcija.Enkriptuj(password));
                return rez;
            }
        }

        public async Task<int> PromeniLozinku(Korisnik korisnik, string novaLozinka)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var entity = await context.Korisnik.FirstOrDefaultAsync(k => k.Username == korisnik.Username);
                entity.Password = Enkripcija.Enkriptuj(novaLozinka);
                return await context.SaveChangesAsync();
            }
        }

        #endregion

        #region Student
        public async Task<Student> GetStudentAsync(long id)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Student.FindAsync(id);
            }
        }

        public async Task<int> GetStudentCountAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Student.CountAsync();
            }
        }

        public async Task<IList<Student>> GetStudentsAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Student
                    .AsNoTracking()
                    .Include(s => s.IdSmeraNavigation)
                        .ThenInclude(d => d.IdDepartmanaNavigation)
                    .ToListAsync();
            }
        }

        public async Task AddStudentAsync(Student student)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                await context.Student.AddAsync(student);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteStudentAsync(params Student[] students)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                foreach (var s in students)
                    context.Student.Remove(s);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateStudentAsync(Student student)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var entity = context.Student.FirstOrDefault(d => d.BrojIndeksa == student.BrojIndeksa);
                entity.Ime = student.Ime;
                entity.Prezime = student.Prezime;
                entity.DatumRodjenja = student.DatumRodjenja;
                entity.Pol = student.Pol;
                entity.Jmbg = student.Jmbg;
                entity.IdSmera = student.IdSmera;
                return await context.SaveChangesAsync();
            }
        }

        #endregion

        #region Ocena

        public async Task<Ocena> GetOcenaAsync(long id)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Ocena.FindAsync(id);
            }
        }

        public async Task<int> GetOcenaCountAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Ocena.CountAsync();
            }
        }

        public async Task<IList<Ocena>> GetOceneAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Ocena
                        .AsNoTracking()
                        .Include(o => o.IdIspitaNavigation)
                            .ThenInclude(i => i.BrojIndeksaStudentaNavigation)
                        .Include(o => o.IdIspitaNavigation)
                            .ThenInclude(i => i.IdPredmetaNavigation)
                        .ToListAsync();
            }
        }

        public async Task AddOCenaAsync(Ocena ocena)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                await context.Ocena.AddAsync(ocena);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateOcenaAsync(Ocena ocena)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var entity = context.Ocena.FirstOrDefault(d => d.IdIspita == ocena.IdIspita);
                entity.Ocena1 = ocena.Ocena1;
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteOcenaAsync(params Ocena[] ocene)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                foreach (var s in ocene)
                    context.Ocena.Remove(s);
                return await context.SaveChangesAsync();
            }
        }


        #endregion

        #region Ispit

        public async Task<Ispit> GetIspitAsync(long id)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Ispit.FindAsync(id);
            }
        }

        public async Task<int> GetIspitCountAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Ispit.CountAsync();
            }
        }

        public async Task<IList<Ispit>> GetIspitiAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Ispit
                    .AsNoTracking()
                    .Include(i => i.BrojIndeksaStudentaNavigation)
                    .Include(i => i.IdPredmetaNavigation)
                    .ToListAsync();
            }
        }

        public async Task AddIspitAsync(Ispit ispit)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                await context.Ispit.AddAsync(ispit);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateIspitAsync(Ispit ispit)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var entity = context.Ispit.FirstOrDefault(d => d.IdIspita == ispit.IdIspita);
                entity.BrojIndeksaStudenta = ispit.BrojIndeksaStudenta;
                entity.IdPredmeta = ispit.IdPredmeta;
                entity.Godina = ispit.Godina;
                entity.NazivRoka = ispit.NazivRoka;
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteIspitAsync(params Ispit[] ispiti)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                foreach (var s in ispiti)
                    context.Ispit.Remove(s);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<IList<IspitOcena>> GetNepolozeneIspite(int idPredmeta, int godina, string nazivRoka)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var idPolozenihIspita = context.Ocena
                    .Select(o => o.IdIspita);
                return await context.Ispit
                        .Include(i => i.BrojIndeksaStudentaNavigation)
                        .Where(i => i.Godina == godina
                            && i.NazivRoka == nazivRoka
                            && i.IdPredmeta == idPredmeta
                            && !idPolozenihIspita.Contains(i.IdIspita))
                        .Select(i => new IspitOcena(i, 5))
                        .OrderBy(i => i.Ispit.BrojIndeksaStudenta)
                        .ToListAsync();
            }
        }

        #endregion

        #region Predmet

        public async Task<Predmet> GetPredmetAsync(long id)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Predmet.FindAsync(id);
            }
        }

        public async Task<int> GetPredmetCountAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Predmet.CountAsync();
            }
        }

        public async Task<IList<Predmet>> GetPredmetiAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Predmet
                            .AsNoTracking()
                            .Include(p => p.IdProfesoraNavigation)
                            .ToListAsync();
            }
        }

        public async Task AddPredmetAsync(Predmet predmet)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                await context.Predmet.AddAsync(predmet);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdatePredmetAsync(Predmet predmet)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var entity = context.Predmet.FirstOrDefault(d => d.IdPredmeta == predmet.IdPredmeta);
                entity.Naziv = predmet.Naziv;
                entity.IdProfesora = predmet.IdProfesora;
                entity.Espb = predmet.Espb;
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeletePredmetAsync(params Predmet[] predmeti)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                foreach (var s in predmeti)
                    context.Predmet.Remove(s);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<IList<PredmetPrijava>> GetNeprijavljeneINepolozenePredmete(int brojIndeksa, int godina, string nazivRoka)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {

                var idPrijavljenihPredmeta = context.Ispit
                    .Where(i => (i.Godina == godina && i.NazivRoka == nazivRoka && i.BrojIndeksaStudenta == brojIndeksa))
                    .Select(i => i.IdPredmeta);
                var idPolozenihPredmeta = context.Ocena
                    .Where(i => i.IdIspitaNavigation.BrojIndeksaStudenta == brojIndeksa)
                    .Select(i => i.IdIspitaNavigation.IdPredmeta);
                var neprijavljeni /* i nepolozeni */ =  await context.Predmet
                    .Where(i => !idPrijavljenihPredmeta.Contains(i.IdPredmeta) && !idPolozenihPredmeta.Contains(i.IdPredmeta))
                    .Select(i => new PredmetPrijava(i, false))
                    .ToListAsync();

                return neprijavljeni;
            }
        }

        #endregion

        #region Profesor

        public async Task<Profesor> GetProfesorAsync(long id)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Profesor.FindAsync(id);
            }
        }

        public async Task<int> GetProfesorCountAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Profesor.CountAsync();
            }
        }

        public async Task<IList<Profesor>> GetProfesorsAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Profesor
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task AddProfesorAsync(Profesor profesor)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                await context.Profesor.AddAsync(profesor);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateProfesorAsync(Profesor profesor)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var entity = context.Profesor.FirstOrDefault(d => d.IdProfesora == profesor.IdProfesora);
                entity.Ime = profesor.Ime;
                entity.Prezime = profesor.Prezime;
                entity.DatumRodjenja = profesor.DatumRodjenja;
                entity.Pol = profesor.Pol;
                entity.IdSmera = profesor.IdSmera;
                entity.Jmbg = profesor.Jmbg;
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteProfesorAsync(params Profesor[] profesors)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                foreach (var s in profesors)
                    context.Profesor.Remove(s);
                return await context.SaveChangesAsync();
            }
        }


        #endregion

        #region Referent

        public async Task<Referent> GetReferentAsync(long id)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Referent.FindAsync(id);
            }
        }

        public async Task<int> GetReferentCountAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Referent.CountAsync();
            }
        }

        public async Task<IList<Referent>> GetReferentsAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Referent
                            .AsNoTracking()
                            .Include(r => r.UsernameReferentaNavigation)
                            .ToListAsync();
            }
        }

        public async Task AddReferentAsync(Referent referent)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                // Prvo dodajem novog korsnika
                Korisnik k = new Korisnik
                {
                    Username = referent.UsernameReferenta,
                    Password = Enkripcija.Enkriptuj("1234"),
                    Usertype = "referent"
                };
                await context.Korisnik.AddAsync(k);
                await context.Referent.AddAsync(referent);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateReferentAsync(Referent referent)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var entity = context.Referent.FirstOrDefault(d => d.UsernameReferenta == referent.UsernameReferenta);
                entity.Ime = referent.Ime;
                entity.Prezime = referent.Prezime;
                entity.DatumRodjenja = referent.DatumRodjenja;
                entity.Pol = referent.Pol;
                entity.Adresa = referent.Adresa;
                entity.Jmbg = referent.Jmbg;
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteReferentAsync(params Referent[] referents)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                // obrisi i korisnika koji odgovara datom referentu
                foreach (var r in referents)
                {
                    Korisnik korisnik = await context.Korisnik.Where(k => k.Username == r.UsernameReferenta).FirstAsync();
                    context.Referent.Remove(r);
                    context.Korisnik.Remove(korisnik);
                }
                    return await context.SaveChangesAsync();
            }
        }


        #endregion

        #region Smer

        public async Task<Smer> GetSmerAsync(long id)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Smer.FindAsync(id);
            }
        }

        public async Task<int> GetSmerCountAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Smer.CountAsync();
            }
        }

        public async Task<IList<Smer>> GetSmeroviAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Smer
                    .AsNoTracking()
                    .Include(s => s.IdDepartmanaNavigation)
                    .Include(s => s.UsernameReferentaNavigation)
                    .ToListAsync();
            }
        }

        public async Task AddSmerAsync(Smer smer)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                await context.Smer.AddAsync(smer);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateSmerAsync(Smer smer)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var entity = context.Smer.FirstOrDefault(d => d.IdSmera == smer.IdSmera);
                entity.Naziv = smer.Naziv;
                entity.IdDepartmana = smer.IdDepartmana;
                entity.UsernameReferenta = smer.UsernameReferenta;
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteSmerAsync(params Smer[] smerovi)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                foreach (var s in smerovi)
                    context.Smer.Remove(s);
                return await context.SaveChangesAsync();
            }
        }

        #endregion

        #region Departman

        public async Task<Departman> GetDepartmanAsync(long id)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Departman.FindAsync(id);
            }
        }

        public async Task<int> GetDepartmanCountAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Departman.CountAsync();
            }
        }

        public async Task<IList<Departman>> GetDepartmaniAsync()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Departman
                    .AsNoTracking()
                    .Include(d => d.IdSefaDepartmanaNavigation)
                    .ToListAsync();
            }
        }

        public async Task AddDepartmanAsync(Departman departman)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                await context.Departman.AddAsync(departman);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteDepartmanAsync(params Departman[] departmani)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                foreach (var s in departmani)
                    context.Departman.Remove(s);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateDepartmanAsync(Departman departman)
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var entity = context.Departman.FirstOrDefault(d => d.IdDepartmana == departman.IdDepartmana);
                entity.Naziv = departman.Naziv;
                entity.IdSefaDepartmana = departman.IdSefaDepartmana;
                return await context.SaveChangesAsync();
            }
        }

        #endregion

        #region Statistika

        public async Task<List<ChartData>> GetPrijavljeniIspitiPoRokovima()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await  context.Ispit
                    .AsNoTracking()
                    .Where(i => i.Godina == 2018)
                    .GroupBy(i => new { i.Godina, i.NazivRoka })
                    .Select(i => new ChartData($"{i.Key.NazivRoka} {i.Key.Godina}", i.Count()))
                    .ToListAsync();
            }
        }

        public async Task<List<ChartData>> GetPolozeniIspitiPoRokovima()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Ocena
                    .AsNoTracking()
                    .Include(i => i.IdIspitaNavigation)
                    .Where(i => i.IdIspitaNavigation.Godina == 2018)
                    .GroupBy(i => new { i.IdIspitaNavigation.Godina, i.IdIspitaNavigation.NazivRoka })
                    .Select(i => new ChartData($"{i.Key.NazivRoka} {i.Key.Godina}", i.Count()))
                    .ToListAsync();
            }
        }

        public async Task<List<ChartData>> GetBrojStudenataPoDepartmanima()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                return await context.Student
                    .AsNoTracking()
                    .Include(s => s.IdSmeraNavigation)
                    .ThenInclude(s => s.IdDepartmanaNavigation)
                    .GroupBy(s => new { s.IdSmeraNavigation.IdDepartmanaNavigation.Naziv })
                    .Select(s => new ChartData(s.Key.Naziv , s.Count()))
                    .ToListAsync();
            }
        }

        public Task<List<ChartData>> GetUspesnostPolaganjePredmeta()
        {
            throw new NotImplementedException();
        }

        // Ovo nisam uspeo da implementiram u ef core, ostavljam ga u sql
        public async Task<List<ChartData>> GetProsecnaOcenaPoPredmetu()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<ChartData>> GetProsecnaOcenaPoDepartmanu()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<ChartData>> GetNajboljiStudenti()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
