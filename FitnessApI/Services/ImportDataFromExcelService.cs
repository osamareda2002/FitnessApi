using FitnessApI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;

namespace FitnessApI.Services
{
    public class ImportDataFromExcelService : IImportDataFromExcelService
    {
        private readonly ApplicationDbContext _context;

        public ImportDataFromExcelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ReadCsvFile()
        {
            string filePath = "D:\\Downloads\\Project files\\DataSets\\nutrients_csvfile.csv";
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(","); // Set the delimiter, change to '\t' for tab-delimited
                int cnt = 0;
                while (!parser.EndOfData)
                {
                    Food food = new Food();
                    string[] fields = parser.ReadFields();
                    if (cnt > 43)
                    {
                        string str1 = fields[2].Contains(",") ? fields[2].Replace(",", "") : fields[2];
                        string str2 = fields[3].Contains(",") ? fields[3].Replace(",", "") : fields[3];
                        // Process the fields array
                        food.FoodName = fields[0];
                        food.Measure = fields[1];
                        food.Grams = fields[2] is double ? double.Parse(str1) : 0;
                        food.Calories = fields[3] is double ? double.Parse(str2) : 0;
                        food.Protein = fields[4] is double ? double.Parse(fields[4]) : 0;
                        food.Fat = fields[5] is double ? double.Parse(fields[5]) : 0;
                        food.Sat_Fat = fields[6] is double ? double.Parse(fields[6]) : 0;
                        food.Fiber = fields[7] is double ? double.Parse(fields[7]) : 0;
                        food.Carbs = fields[8] is double ? double.Parse(fields[8]) : 0;
                        food.Category = fields[9];
                        
                        _context.Foods.Add(food);
                        _context.SaveChanges();
                        
                    }
                    cnt++;
                }
            }
        }

    }
}
