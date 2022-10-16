#pragma warning disable CS8600
#pragma warning disable CS8602

// Get 2 string number from input
string num1 = Console.ReadLine();
string num2 = Console.ReadLine();

// Separate flot type and integer of numbers
List<int>[] SeparateFlot(string flotNumber)
{
    List<int> francPart = new List<int>();
    List<int> intPart = new List<int>();
    bool reachFlot = false;
    for (var i = 0; i < flotNumber.Length; i++)
    {
        if (flotNumber[i] == '.')
        {
            reachFlot = true;
            continue;
        }

        if (!reachFlot)
        {
            intPart.Add(flotNumber[i] - '0');
            continue;
        }
        francPart.Add(flotNumber[i] - '0');
    }

    return new [] {intPart, francPart};
}

// Store integer and fractional part of number in different lists
List<int> intNum1 = SeparateFlot(num1)[0];
List<int> francNum1 = SeparateFlot(num1)[1];
List<int> intNum2 = SeparateFlot(num2)[0];
List<int> francNum2 = SeparateFlot(num2)[1];

// Make frac numbers flot equal
int count1 = francNum1.Count;
int count2 = francNum2.Count;
int diff = Math.Abs(count1 - count2);
if (count1 > count2)
{
    for (var i = 0; i < diff; i++) {
        francNum2.Insert(francNum2.Count, 0);
    }
}
else
{
    for (var i = 0; i < diff; i++) {
        francNum1.Insert(francNum1.Count  , 0);
    }
}

// Make int numbers count equal
count1 = intNum1.Count;
count2 = intNum2.Count;
diff = Math.Abs(count1 - count2);
if (count1 > count2)
{
    for (var i = 0; i < diff; i++) {
        intNum2.Insert(0, 0);
    }
}
else
{
    for (var i = 0; i < diff; i++) {
        intNum1.Insert(0  , 0);
    }
}

// Adding fractional parts of numbers
int count = francNum1.Count;
int counter = 0;
int carry = 0;

while (counter < count) {
    var index = (count - counter) -1;
    int sum = francNum1[index] + francNum2[index] + carry;
 
    francNum1[index] = sum % 10;
    carry = (sum >= 10) ? 1 : 0;
    counter++;
}

count = intNum1.Count;
counter = 0;
// Add integer part of numbers + carry
while (counter < count) {
    var index = (count - counter) -1;
    int sum = intNum1[index] + intNum2[index] + carry;
 
    intNum1[index] = sum % 10;
    carry = (sum >= 10) ? 1 : 0;
    counter++;
}

if (carry != 0)
    intNum1.Add(carry);

foreach(int n in intNum1) Console.Write(n);
Console.Write(".");
foreach(int n in francNum1) Console.Write(n);
