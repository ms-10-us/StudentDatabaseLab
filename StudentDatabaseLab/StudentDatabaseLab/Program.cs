//Calling and Running Methods
Console.WriteLine("Welcome to Student Database Lab!");
bool isContinuing = false;
do
{
    Console.WriteLine();

    string[] arrayOfNames = new string[9] { "Scott", "Roland", "Mazen", "Lucas", "Jennifer", "Alex", "Melissa", "Harry", "Julian" };
    string[] arrayOfHometowns = new string[9] { "Livonia", "Plymoth", "Novi", "Northville", "Farmington Hills", "Oakland", "Detroit", "Westland", "Grand Rapids" };
    string[] arrayOfFood = new string[9] { "Pizza", "Italian Sandwich", "Taco", "Burritto", "Hamburger", "Ice Cream", "Spagetti", "Salad", "Rice" };

    Console.WriteLine("Do you want to list the database? (y/n)");
    string listDatabaseAnswer = Console.ReadLine();
    bool isListingDatabase = true;
    while (isListingDatabase)
    {
        if (listDatabaseAnswer.ToLower().Trim() == "y")
        {
            PrintDatabase(arrayOfNames);
            isListingDatabase = false;
        }
        else if (listDatabaseAnswer.ToLower().Trim() == "n")
        {
            Console.WriteLine("Okay. Database will not be printed");
            isListingDatabase = false;
        }
        else
        {
            Console.WriteLine("Please enter a valid responce");
            listDatabaseAnswer = Console.ReadLine();
            isListingDatabase = true;
        }
        
    }

    Console.WriteLine();

    Console.WriteLine("Do you want to search the databse? (y/n)");
    string searchDatabaseAnswer = Console.ReadLine();
    bool isSearchingDatabse = true;
    while(isSearchingDatabse)
    {
        if(searchDatabaseAnswer.ToLower().Trim() == "y")
        {
            Console.WriteLine("Enter the student Name");
            string nameOfStudent  = Console.ReadLine();
            SearchStudent(nameOfStudent.ToLower().Trim(), arrayOfNames);
            isSearchingDatabse = false;
        }
        else if (searchDatabaseAnswer.ToLower().Trim() == "n")
        {
            Console.WriteLine("Okay. I will not search the database");
            isSearchingDatabse = false;
        }
        else
        {
            Console.WriteLine("Please enter a valid responce");
            searchDatabaseAnswer = Console.ReadLine();
            isSearchingDatabse = true;
        }
    }

    Console.WriteLine();

    Console.WriteLine("Which student would you like to learn more about? Enter a number 1-9.");
    string userNumberString = Console.ReadLine();
    int studentNumber = 0;
    bool isValidNumber = GetUserNumber(userNumberString, out studentNumber, arrayOfNames);

    string studentName = GetStudentName(arrayOfNames, studentNumber);
    Console.WriteLine($"Student {studentNumber} is {studentName}");

    Console.WriteLine();

    Console.WriteLine("What would you like to know? Enter hometown or food");
    string category = Console.ReadLine();
    bool isCategoryValid = IsValidCategory(category);
    while (!isCategoryValid)
    {
        Console.WriteLine("That category does not exist. Please try again");
        category = Console.ReadLine();
        isCategoryValid = IsValidCategory(category);
    }

    switch (category)
    {
        case "hometown":
        case "home":
        case "town":
            string hometown = GetCategory(arrayOfHometowns, studentNumber);
            Console.WriteLine($"{studentName} is from {hometown}");
            Console.WriteLine();
            break;
        case "food":
        case "favorite":
        case "favorite food":
            string food = GetCategory(arrayOfFood, studentNumber);
            Console.WriteLine($"{studentName} likes {food}");
            Console.WriteLine();
            break;
    }

    Console.WriteLine("Would you like to learn about another student? (y/n)");
    string userAnswer = Console.ReadLine();
    isContinuing = ContinueExcercise(userAnswer);
} while (isContinuing);

if (!isContinuing)
{
    Console.WriteLine("Thanks!");
}


// Methods Signatures
bool GetUserNumber(string userNumberString, out int number, string[] array)
{
    bool isValidNumber = int.TryParse(userNumberString, out number);
    if (!isValidNumber || number < 1 | number > array.Length)
    {
        Console.WriteLine("Please enter a valid number");
        userNumberString = Console.ReadLine();
        isValidNumber = GetUserNumber(userNumberString, out number, array);
    }
    return isValidNumber;
}


string GetStudentName(string[] studentNames, int studentNumber)
{
    string studentName = studentNames[studentNumber - 1];
    return studentName;
}

string GetCategory(string[] categoryArray, int categoryNumber)
{
    string category = categoryArray[categoryNumber - 1];
    return category;
}

bool IsValidCategory(string category)
{
    bool isValidCategorie = false;

    if (category.ToLower() == "hometown" || category.ToLower() == "food")
    {
        isValidCategorie = true;
    }

    return isValidCategorie;

}

bool ContinueExcercise(string userAnswer)
{
    bool isContinuing = false;

    if (userAnswer.ToLower() == "y")
    {
        isContinuing = true;
    }
    else if (userAnswer.ToLower() == "n")
    {
        isContinuing = false;
    }

    return isContinuing;
}

void PrintDatabase(string[] studentNames)
{
    for (int i = 0; i < studentNames.Length; i++)
    {
        Console.WriteLine($"{i + 1} {studentNames[i]}");
    }
}

void SearchStudent(string studentName , string[] studentNames)
{
    bool isFound = false;

    for (int i = 0; i < studentNames.Length; i++)
    {
        if (studentName.ToLower().Trim() == studentNames[i].ToLower().Trim())
        {
            Console.WriteLine($"{studentName} is in the database");
            isFound = true;
            break;
        }
    }
     if (!isFound)
    {
        Console.WriteLine($"{studentName} is not in the database");
    }
}
















