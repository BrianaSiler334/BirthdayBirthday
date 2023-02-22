using System.Net.Security;
using System.Runtime.CompilerServices;

namespace Birthday_Birthday {
    internal class Program {

        struct Birthdays {
            public string lastName;
            public string firstName;
            public string sex;
            public int monthBorn;
            public int dayBorn;
            public int yearBorn;

        }//end struct
        static void Main(string[] args) {
            

            string path = @"C:\Users\BSiler\Downloads\PeopleData.csv";
            string data = "";
            string[] records;
            string userInput = "";
            int month;
            int year;
            bool parsingSuccesful = false;
           
            
            Birthdays[] person;
            //READ DATA FROM FILE
            FileStream inFile = new FileStream(path, FileMode.Open);

            while (inFile.Position < inFile.Length) {
                data += (char)inFile.ReadByte();
            }//end while loop

            inFile.Close();
            //SPLIT DATA INTO RECORDS
            records = data.Split("\r\n");

            //CREATE AN ARRAY OF PERSON TO HOLD EACH RECORD
            person = new Birthdays[records.Length - 1];

            
             bool parseSuccessful = false;
            
            //POPULATE ARRAY OF PERSON(SKIPPING THE HEADER ROW)
            for (int index = 1; index < records.Length; index++ ) {


                //GET A RECORD
                string currentRecord = records[index];

                //SPLIT THE RECORD
                string[] fields = currentRecord.Split(",");

                //STORE TO PERSON STRUCT[LAST NAME, FIRST NAME, SEX, MONTH BORN, DAY BORN, YEAR BORN
                person[index - 1].lastName  = fields[0];
                person[index - 1].firstName = fields[1];
                person[index - 1].sex       = fields[2];
                int.TryParse(fields[3], out person[index - 1].yearBorn);             
                int.TryParse(fields[4], out person[index - 1].monthBorn);
                int.TryParse(fields[5], out person[index - 1].dayBorn);

            }//end for
            Console.WriteLine("\nEnter a month and year to search for birthdays): ");
            Console.WriteLine("----------------------------");

            //DO WHILE LOOP FOR INPUT

            do {
                    userInput = Input("Enter month: ");
                    parsingSuccesful = int.TryParse(userInput, out month);
            } while (parsingSuccesful == false || month >=13 );
            
            
            do {
                    userInput = Input("Enter Year: ");
                    parsingSuccesful = int.TryParse(userInput, out year);
            } while (parsingSuccesful == false || year  <= 1900);
            
            Console.WriteLine("-----------");
            
            //FOR LOOP TO GO THROUGH FILE
            for (int i = 1; i < person.Length; i++) {
                string male = "Male";
                string female = "Female";

                //IF STATEMENT
                if (person[i].monthBorn == month && person[i].yearBorn == year) {

                    

                    if (person[i].sex == male) {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{person[i].firstName} {person[i].lastName} 0{person[i].monthBorn}/{person[i].dayBorn}/{person[i].yearBorn}");
                    } else if (person[i].sex == female) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{person[i].firstName} {person[i].lastName} 0{person[i].monthBorn}/{person[i].dayBorn}/{person[i].yearBorn}");
                    } else {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"{person[i].firstName} {person[i].lastName} 0{person[i].monthBorn}/{person[i].dayBorn}/{person[i].yearBorn}");
                    }//end if
                    

                } //end if
                
            }//end for
            
            


        }//end main

        static string Input(string prompt) {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

       
    }//end class
}//end namespace