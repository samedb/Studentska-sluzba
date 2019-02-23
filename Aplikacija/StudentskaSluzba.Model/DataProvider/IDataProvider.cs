using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model.Models
{
    public interface IDataProvider
    {
        Task<Student> GetStudentAsync(long id);
        Task<IList<Student>> GetStudentsAsync();
        Task<int> GetStudentCountAsync();
        Task AddStudentAsync(Student student);
        Task<int> UpdateStudentAsync(Student student);
        Task<int> DeleteStudentAsync(params Student[] students);


        Task<Ocena> GetOcenaAsync(long id);
        Task<IList<Ocena>> GetOceneAsync();
        Task<int> GetOcenaCountAsync();
        Task AddOCenaAsync(Ocena ocena);
        Task<int> UpdateOcenaAsync(Ocena ocena);
        Task<int> DeleteOcenaAsync(params Ocena[] ocene);

        Task<Ispit> GetIspitAsync(long id);
        Task<IList<Ispit>> GetIspitiAsync();
        Task<int> GetIspitCountAsync();
        Task AddIspitAsync(Ispit ispit);
        Task<int> UpdateIspitAsync(Ispit ispit);
        Task<int> DeleteIspitAsync(params Ispit[] ispiti);
        Task<IList<IspitOcena>> GetNepolozeneIspite(int idPredmeta, int godina, string nazivRoka);

        Task<Predmet> GetPredmetAsync(long id);
        Task<IList<Predmet>> GetPredmetiAsync();
        Task<int> GetPredmetCountAsync();
        Task AddPredmetAsync(Predmet predmet);
        Task<int> UpdatePredmetAsync(Predmet predmet);
        Task<int> DeletePredmetAsync(params Predmet[] predmeti);
        Task<IList<PredmetPrijava>> GetNeprijavljeneINepolozenePredmete(int brojIndeksa, int godina, string nazivRoka);

        Task<Profesor> GetProfesorAsync(long id);
        Task<IList<Profesor>> GetProfesorsAsync();
        Task<int> GetProfesorCountAsync();
        Task AddProfesorAsync(Profesor profesor);
        Task<int> UpdateProfesorAsync(Profesor profesor);
        Task<int> DeleteProfesorAsync(params Profesor[] profesors);

        Task<Referent> GetReferentAsync(long id);
        Task<IList<Referent>> GetReferentsAsync();
        Task<int> GetReferentCountAsync();
        Task AddReferentAsync(Referent referent);
        Task<int> UpdateReferentAsync(Referent referent);
        Task<int> DeleteReferentAsync(params Referent[] referents);

        Task<Smer> GetSmerAsync(long id);
        Task<IList<Smer>> GetSmeroviAsync();
        Task<int> GetSmerCountAsync();
        Task AddSmerAsync(Smer smer);
        Task<int> UpdateSmerAsync(Smer smer);
        Task<int> DeleteSmerAsync(params Smer[] smerovi);

        Task<Departman> GetDepartmanAsync(long id);
        Task<IList<Departman>> GetDepartmaniAsync();
        Task<int> GetDepartmanCountAsync();
        Task AddDepartmanAsync(Departman departman);
        Task<int> UpdateDepartmanAsync(Departman departman);
        Task<int> DeleteDepartmanAsync(params Departman[] departmani);

        Task<List<ChartData>> GetPrijavljeniIspitiPoRokovima();
        Task<List<ChartData>> GetPolozeniIspitiPoRokovima();
        Task<List<ChartData>> GetBrojStudenataPoDepartmanima();
        Task<List<ChartData>> GetUspesnostPolaganjePredmeta();
        Task<List<ChartData>> GetProsecnaOcenaPoPredmetu();
        Task<List<ChartData>> GetProsecnaOcenaPoDepartmanu();
        Task<List<ChartData>> GetNajboljiStudenti();
    }
}
