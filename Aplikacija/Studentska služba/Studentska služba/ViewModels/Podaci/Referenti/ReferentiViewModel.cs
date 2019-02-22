using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Referenti
{
    public class ReferentiViewModel : GenericCRUDViewModel<Referent>
    {

        protected async override Task<IList<Referent>> GetItems()
        {
            return await dataProvider.GetReferentsAsync();
        }

        protected override async Task AddItemAsync()
        {
            await dataProvider.AddReferentAsync(SelectedItem);
        }

        protected override async Task UpdateItem()
        {
            await dataProvider.UpdateReferentAsync(SelectedItem);
        }

        protected override async Task RemoveItemAsync()
        {
            await dataProvider.DeleteReferentAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }


        ///// <summary>
        ///// Kad dodajem novog refeernta moram da dodam i novog korsinika u tabeli Korisnik
        ///// </summary>
        //protected override void AddItemAsync()
        //{
        //    //TODO Da ispravim ovo
        //    //context.Korisnik.Add(new Korisnik
        //    //{
        //    //    Username = SelectedItem.UsernameReferenta,
        //    //    Password = "1234",
        //    //    Usertype = "referent"
        //    //});
        //    //base.AddItemAsync();
        //}


        ///// <summary>
        ///// Takodje kad brisem referenta moram posle toga i da ga izbirsem iz tabele korisnik
        ///// </summary>
        protected override async void DeleteSelectedStudent()
        {
            var k = new Korisnik { Username = SelectedItem.UsernameReferenta };
            using (var context = new StudentskaSluzbaDBContext())
            {
                context.Korisnik.Remove(k);
                context.Referent.Remove(SelectedItem);
                await context.SaveChangesAsync();
            }
            SelectedItem = default(Referent);
            RefreshTable();
        }

        protected override async Task<ObservableCollection<Referent>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Referent>)
                .Where(t =>
                    Sadrzi(t.UsernameReferenta, text) ||
                    Sadrzi(t.Ime, text) ||
                    Sadrzi(t.Prezime, text))
                .ToList();
            return new ObservableCollection<Referent>(list);
        }
    }
}
