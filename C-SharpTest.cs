using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SampleConApp
{
    class Disease
    {
        public string Name { get; set; }
        public string Severity { get; set; } 
        public string Cause { get; set; }
        public string Description { get; set; }

      
       
    }
    class Symptoms
    {
        public string DiseaseName { get; set; }
        public string[] DiseaseSymptoms { get; set; }
        public string DescOfSymptom { get; set; }

    }
   
    class DiseaseAdder
    {
        private Disease[] _diseases = null;
        private Symptoms[] _symptoms = null;
        private int _size = 0;

        public DiseaseAdder(int size)
        {
            _size = size;
            _diseases = new Disease[_size];
            _symptoms = new Symptoms[_size];
        }

        public void AddNewDisease(Disease d)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_diseases[i] == null)
                {
                    _diseases[i] = new Disease { Name = d.Name, Severity = d.Severity, Description = d.Description, Cause = d.Cause };
                    return;
                }
            }
        }

        //public bool DiseaseChecker(string name)
        //{
        //    for (int i = 0; i < _size; i++)
        //    {
                
        //    }
        //    return true;
        //}
        public Disease Finddisease(string name)
        {
            foreach (Disease d in _diseases)
            {
                if (d != null && d.Name == name)
                    return d;
            }
            throw new Exception("No Disease found with the name "+name);
        }

        public string getDiseaseDetails(Disease d)
        {
            return $"{d.Name}\n{d.Severity}\n{d.Cause}\n{d.Description}";
        }

        public void AddSymptoms(Symptoms s)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_symptoms[i] == null)
                {
                    _symptoms[i] = new Symptoms { DiseaseName = s.DiseaseName,DescOfSymptom=s.DescOfSymptom,DiseaseSymptoms=s.DiseaseSymptoms };
                    return;
                }
            }
        }
        public void showSymptoms()
        {
            try
            {
            ArrayList al = new ArrayList();
            for (int i = 0; i < _size; i++)
            {
            Symptoms s = _symptoms[i];
                for (int j = 0; j < s.DiseaseSymptoms.Length; j++)
                {
                    
                    al.Add(s.DiseaseSymptoms[j]);

                    Console.WriteLine(s.DiseaseSymptoms[j]);
                }
            }

            }
            catch (Exception)
            {

                Console.WriteLine(" ");
            }
        }
        public void compareSymptoms(string[] s)
        {
            try
            {
                string[] arr = new string[_size];
            for (int i = 0; i < s.Length; i++)
            {
                for (int k = 0; k < _size; k++)
                {
                    Symptoms simp = _symptoms[k];
                    for (int j = 0; j < simp.DiseaseSymptoms.Length; j++)
                    {

                        if (s[i] == simp.DiseaseSymptoms[j])
                        {
                                arr[k] = simp.DiseaseName;
                           // Console.WriteLine(simp.DiseaseName);
                            j = simp.DiseaseSymptoms.Length;
                        }
 
                    }
                        k = simp.DiseaseSymptoms.Length;
                    
                }
            }
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            
        }
    }
    class DiseaseConsoleUI
    {
      public static DiseaseAdder da = null;

        internal static void menu()
        {
            int size = Utilities.GetNumber("Enter the number of diseases you want to Add");
            da = new DiseaseAdder(size);
            bool proc = true;
            do
            {
                Console.WriteLine("********************************************************************************************");
                Console.WriteLine("enter 1 “Add Disease Details” \nenter 2 “Add Symptom to Disease” \nenter 3 “Check Patient”");
                Console.WriteLine("********************************************************************************************");
                int choice = Utilities.GetNumber("enter the number ");
                proc = ProcessingMenu(choice);
            } while (proc);
            Console.WriteLine("Thanks for using our application");
        }
        
        private static bool ProcessingMenu( int choice)
        {
            switch (choice)
            {
                case 1:
                    AddDiseaseHelper();
                    break;
                case 2:
                   AddSymptomsHelper();
                    break;
                case 3:
                    CheckPatientHelper();
                    break;

               

                default:
                    return false;
            }
            return true;
        }

        private static void CheckPatientHelper()
        {
            string s = Utilities.Prompt("enter the patient name ");
            Console.WriteLine();
            da.showSymptoms();
            string symps = Utilities.Prompt("Enter the symptoms associated with disease as shown above each seperated by a comma ");
            Console.WriteLine();
            string[] symptoms = symps.Split(',');

            
            Console.WriteLine();
            Console.WriteLine("Patient "+s+" may have similar symptoms to the following diseases ");
            da.compareSymptoms(symptoms);
            Console.WriteLine();

            string searchName = Utilities.Prompt("Enter the name of the disease to get details ");

            Console.WriteLine(da.getDiseaseDetails(da.Finddisease(searchName)));
            

        }

        private static void AddSymptomsHelper()
        {
            string name = Utilities.Prompt("enter the name of the disease");

         
            string descOfSymptoms = Utilities.Prompt("enter the description of symptoms ");
            string symptoms = Utilities.Prompt("Enter the symptoms associated with disease each seperated by a comma ");
            string[] simp = symptoms.Split(',');

            Symptoms s = new Symptoms { DiseaseName = name, DescOfSymptom = descOfSymptoms, DiseaseSymptoms = simp };
            da.AddSymptoms(s);

            Console.WriteLine("Symptoms added successfully!!!");
            Console.WriteLine("");
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }

        private static void AddDiseaseHelper()
        {
            string name = Utilities.Prompt("enter the name of the disease");
            string severity = Utilities.Prompt("Enter the severity of disease \n in terms of - high / Medium / low");
            String cause = Utilities.Prompt("enter the cause of the disease");
            bool x = true;
            string desc = null;
            do
            {
                desc = Utilities.Prompt("enter the description of the disease more than 30 Characters ");
                if (desc.Length < 30)
                {
                    Console.WriteLine("description entered is less than 30 characters");
                }
                else x = false;
            } while (x);

            Disease d = new Disease { Name = name, Severity = severity, Cause = cause, Description = desc };
            da.AddNewDisease(d);
            Console.WriteLine("Disease added successfully!!!");
            Console.WriteLine("");
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();

        }
    }
    class C_SharpTest
    {
        static void Main(string[] args)
        {
           // Disease d = new Disease { };
        DiseaseConsoleUI.menu();
            
        }
    }
}
