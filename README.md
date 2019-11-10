# Robots OOP Sample
 
 Vytvoril som hru **Lab**, v ktorej sú roboti ktorí pracujú a oddychujú.
 
 ![Robots](https://teens.drugabuse.gov/sites/default/files/styles/medium/public/blog/robots_optimized.jpg?itok=V4tFVO8H)

Ako prvé som vytvoril triedu `Robot`, ktorá reprezentuje všetkých robotov.

```csharp
class Robot
{
}
```

Každý robot má vlastnosti:
Ako prvú som nastavil **meno**. `Name` po nastavení nemôže byť zmenené.

```csharp
class Robot
{
    public Robot(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
```

Každý robot má tiež **život**, ktorý keď sa minie, robot sa pokazí. `Healthpoints` musí byť nastavené ale môže byť zmenené.

```csharp
class Robot
{
    public Robot(string name, int healthpoints)
    {
        Name = name;
        Healthpoints = healthpoints;
    }

    public string Name { get; }
    public int Healthpoints { get; set; }
}
```

Každý robot má **batériu**, ktorá sa bude postupne vybíjať. `Battery` musí byť nastavené ale môže byť zmenené.

```csharp
class Robot
{
    public Robot(string name, int healthpoints, int battery)
    {
        Name = name;
        Healthpoints = healthpoints;
        Battery = battery;
    }

    public string Name { get; }
    public int Healthpoints { get; set; }
    public int Battery { get; set; }
    
}
```
Každý robot má nezmeniteľné hranice `Maxhealthpoints` a `Maxbattery`, ktoré sa starajú o to aby `Healthpoints` a `Battery` nepresiahli hranice.

```csharp
class Robot
{
    public Robot(string name, int healthpoints, int battery, int maxhealthpoints, int maxbattery)
    {
        Name = name;
        Healthpoints = healthpoints;
        Battery = battery;
        Maxhealthpoints = maxhealthpoints;
        Maxbattery = maxbattery;
    }

    public string Name { get; }
    public int Healthpoints { get; set; }
    public int Battery { get; set; }
    public int Maxhealthpoints { get; }
    public int Maxbattery { get; }
    
}
```

Toľko k vlastnostiam.
Pokračujeme metódou update, ktorá sa uplatní po každom stlačení klávesy **Enter**.

```csharp
public void Update()
        {
            if (Healthpoints <= 0) return;
            Battery--;
            if (Battery > Maxbattery)
            {
                Battery = Maxbattery;
            }
            if (Battery > 0)
            {
                Healthpoints--;
                if (Healthpoints > (Maxhealthpoints / 2))
                {
                    Console.WriteLine($"{Name} is working.");
                }
                if (Healthpoints > 0 && Healthpoints <= (Maxhealthpoints / 2))
                {
                    Console.WriteLine($"{Name} is overworked.");
                }
                if (Healthpoints <= 0)
                {
                    Console.WriteLine($"{Name} was destroyed.");
                    Healthpoints = 0;
                }
            }
            if (Battery <= 0 && Healthpoints > 0)
            {
                Healthpoints++;
                if (Healthpoints > Maxhealthpoints)
                {
                    Healthpoints = Maxhealthpoints;
                }

                if (Healthpoints < (Maxhealthpoints / 2))
                {
                    Console.WriteLine($"{Name} is recovering.");
                }
                if (Healthpoints >= (Maxhealthpoints / 2) && Healthpoints < Maxhealthpoints)
                {
                    Console.WriteLine($"{Name} is resting.");
                }
                if (Healthpoints == Maxhealthpoints)
                {
                    Console.WriteLine($"{Name} is turned off.");
                }
                Battery = 0;
            }
        }
```

* Ak robot ešte funguje `Battery` sa zníži o 1.
* Ak je `Battery` viac ako `Maxbattery`, `Battery` sa nastaví na `Maxbattery`.

* Ak je `Battery` viac ako 0 (teda robot pracuje) tak:
* `Healthpoints` sa zníži o 1.
* Ak je `Healthpoints` viac ako  polovica `Maxhealthpoints` tak píše: Robot pracuje.
* Ak je `Healthpoints` menej alebo sa rovná ako  polovica `Maxhealthpoints` tak píše: Robot je prepracovaný.
* Ak `Healthpoints` sa rovná alebo je menej ako 0 tak píše: Robot sa pokazil.
* Ak je `Battery` menej alebo sa rovná 0 (robot nepracuje) a zároveń je `Healthpoints` viac ako 0 tak:
* `Healthpoints` sa zvýši o 1.
* Ak je `Healthpoints` menej ako polovica `Maxhealthpoints` tak píše: Robot sa zotavuje.
* Ak je `Healthpoints` viac ale bo sa rovná polovici `Maxhealthpoints` tak píše: Robot odpočíva.
* Ak `Healthpoints` sa rovná `Maxhealthpoints` tak píše: Robot je vypnutý.
* Nakoniec sa v prípade druhej možnosti nastaví `Battery` na 0.

Teraz vytvorím novú metódu aby sa roboty mohli nabíjať.

Táto metóda im pridá hodnotu batérie.

```csharp
public void Charger(int energy)
        {
            Battery += energy;
        }
```

Vytvoríme novú triedu `Lab`, v ktorej bude zoznam robotov a ďalšie metódy.

```csharp
class Lab
{
}
```

Do triedy pridáme zoznam robotov.

```csharp
private readonly List<Robot> robots;

        public Lab()
        {
            robots = new List<Robot>
            {
                new Robot("Android", 50, 0, 50, 10),
                new Robot("Megatron", 250, 0, 250, 80),
                new Robot("Mettaton", 150, 0, 150, 30),
                new Robot("Golem", 200, 0, 200, 50),
                new Robot("Oxygen", 30, 0, 30, 4),
                new Robot("Rob Bott", 20, 0, 20, 10),
                new Robot("Terminator", 230, 0, 230, 200),
            };
        }
```

Teraz vytvoríme metódu `Update`, ktorá zavolá metódu `Update` z triedy `Robot` a uplatní ju pre každý objekt v zozname.

```csharp
public void Update()
        {
            foreach (var robot in robots)
            {
                robot.Update();
            }
        }
```

Vytvoríme metódy `ChargeUp` a `FindRobotBy`.

Metóda `FindRobotBy` skontroluje či zadaný *string* sa zhoduje s menom robota v zozname.

Pokiaľ metóda `FindRobotBy` vráti robota zo zoznamu, nabije robota.

```csharp
public void ChargeUp(string name, int energy)
        {
            Robot robot = FindRobotBy(name);
            if (robot != null)
            {
                robot.Charger(energy);
            }
        }

        private Robot FindRobotBy(string name)
        {
            foreach (var robot in robots)
            {
                if (robot.Name.ToLower() == name.ToLower())
                {
                    return robot;
                }
            }
            return null;
        }
```

Nakoniec v Main triede:

* Vytvoríme var `lab`, ktorý zavolá triedu `Lab`.
* Pridáme pár **Console.WriteLine** príkazov.
* Po stalačení klávesy **Enter** sa zavolá metóda `Update` z triedy `Lab`
* Vypíše sa **Console.WriteLine** príkaz
* ako nový *string* `input` sa nastaví **Console.ReadLine**
* a zavolá sa metóda `ChargeUp` z triedy `Lab` s parametrami `input` a **10**

```csharp
static void Main(string[] args)
        {
            var lab = new Lab();
            Console.WriteLine("Press CTRL+C to exit.");
            Console.WriteLine("If you don't want to charge any robot just press Enter.");
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                lab.Update();
                Console.WriteLine("Which robot would you like to charge?");
                string input = Console.ReadLine();
                lab.ChargeUp(input, 10);
            }
        }
```
Koniec programu.
