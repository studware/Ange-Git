using System;

public class Chef
{
    public void Cook()
    {
        Bowl bowl = GetBowl();

        Carrot carrot = GetCarrot();
        Peel(carrot);
        Cut(carrot);
        bowl.Add(carrot);

        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);
        bowl.Add(potato);
    }

    private Bowl GetBowl()
    {
        throw new NotImplementedException();
    }

    private Carrot GetCarrot()
    {
        throw new NotImplementedException();
    }

    private Potato GetPotato()
    {
        throw new NotImplementedException();
    }

    private void Cut(Vegetable vegetable)
    {
        throw new NotImplementedException();
    }

    private void Peel(Vegetable vegetable)
    {
        throw new NotImplementedException();
    }
}