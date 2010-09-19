using System.Collections.ObjectModel;

namespace WindowsPresentationFramework
{
    public partial class ComboBoxWithObjectWindow
    {
        private readonly People clubMembers;

        public ComboBoxWithObjectWindow()
        {
            InitializeComponent();
            clubMembers = new People();
            theListBox.DataContext = clubMembers;

            string[] womensClub = { 
                                  "Anne", 
                                  "Bridget", 
                                  "Barbara",
                                  "Brenda", 
                                  "Bertha", 
                                  "Charlene", 
                                  "Georgina", 
                                  "Harriet", 
                                  "Ivona", 
                                  "Janice", 
                                  "Kate", 
                                  "Kathleen",
                                  "Louise",
                                  "Loni",
                                  "Louisa",
                                  "Michele",
                                  "Marie",
                                  "Maria",
                                  "Mary",
                                  "Mari",
                                  "Nanette",
                                  "Nancy", 
                                  "Opra",
                                  "Pamela",
                                  "Paula",
                                  "Patsie",
                                  "Tammy",
                              };
            foreach (string name in womensClub)
            {
                clubMembers.Add(new Person(name));
            }
        }
    }

    internal class People : ObservableCollection<Person> {}

    internal class Person
    {
        public Person(string n)
        {
            Name = n;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}