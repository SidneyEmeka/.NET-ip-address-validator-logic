string[] ipv4Input = {"107.31.1.5", "255.0.0.255", "555..0.555", "255...255"};
string[] address; //An array to store the ip being validated
bool validLength = false;
bool validZeroes = false;
bool validRange = false;

foreach (string ip in ipv4Input) //To loop through all the arrays in ipv4Input
{
    address = ip.Split(".", StringSplitOptions.RemoveEmptyEntries); //To omit empty/remove strings like 255..5255, cos our split method checks for . not ..

    ValidateLength(); //calling the methods used to validate the Length
    ValidateZeroes(); //calling the methods used to validate the Start of the iP
    ValidateRange(); //calling the methods used to validate the Range

    if (validLength && validZeroes && validRange == true) 
    {
        Console.WriteLine($"{ip} is a valid IPv4 address");
    } 
    else 
    {
        Console.WriteLine($"{ip} is an invalid IPv4 address");
    }
}

//Defining the Methods
void ValidateLength() 
{
    validLength = address.Length == 4;
};

void ValidateZeroes() 
{
    foreach (string number in address) 
    {
        if (number.Length > 1 && number.StartsWith("0")) 
        {
            validZeroes = false;
            return;
        }
    }

    validZeroes = true;
}

void ValidateRange() 
{
    foreach (string number in address) 
    {
        int value = int.Parse(number);
        if (value < 0 || value > 255) 
        {
            validRange = false;
            return;
        }
    }
    validRange = true;
}