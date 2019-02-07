using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Referenti
{
    public class ReferentiViewModel : GenericCRUDViewModel<Referent>
    {
        protected override object GetDbSet()
        {
            return context.Referent;
        }

        protected override void GetItems()
        {
            ItemList = (GetDbSet() as DbSet<Referent>)
                .Include(r => r.UsernameReferentaNavigation)
                .ToList();
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }


        ///// <summary>
        ///// Kad dodajem novog refeernta moram da dodam i novog korsinika u tabeli Korisnik
        ///// </summary>
        protected override void AddItem()
        {
            context.Korisnik.Add(new Korisnik
            {
                Username = SelectedItem.UsernameReferenta,
                Password = "1234",
                Usertype = "referent"
            });
            base.AddItem();
        }


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

        protected override List<Referent> SearchForItem(string text)
        {
            return context.Referent
                .Where(t =>
                    t.UsernameReferenta.Contains(text) ||
                    t.Ime.Contains(text) ||
                    t.Prezime.Contains(text))
                .ToList();
        }
    }
}
