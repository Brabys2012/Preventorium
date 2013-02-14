using System.Collections;
/// <summary>
/// Класс ингридиенты: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_ingridients
{
    public string result;
    public string ingr_id;
    public string name;
    public string protein;
    public string uglevod;
    public string zhiri;
    public string calories;
}

/// <summary>
/// Класс блюда: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_food
{
    public string result;
    public string food_id;
    public string name;
    public string calories;
    public string proteins;
    public string fats;
    public string carbo;
    public string weight;
}
/// <summary>
/// Класс диеты: Содержит переменные которым передаются значения по sql запросу.
/// /// </summary>
public class class_diet
{
    public string result;
    public string diet_id;
    public string numbDiet;
    public string description;
}

/// <summary>
/// Класс книги: Содержит переменные которым передаются значения по sql запросу
/// </summary>

public class class_book
{
    public string result;
    public string book_id;
    public string author;
    public string year;
    public string name;
}

/// <summary>
/// Класс игридиенты в блюде: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_ingr_food
{
    public string result;
    public string net;
    public string bruto;  
}

/// <summary>
/// Класс карта-ракскладка: Содержит переменные которым передаются значения по sql запросу.
/// /// </summary>
public class class_cards
{
    public string result;
    public string id;
    public string opis;
    public string cost;
    public string nam_card;
}
/// <summary>
/// Класс должность: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_post
{
    public string id;
    public string result;
}

/// <summary>
/// Класс персона: Содержит переменные которым передаются значения по sql запросу
/// </summary>

public class person
{
    public string result;
    public string name;
    public string surname;
    public string secondname;
}

/// <summary>
/// Класс ингридиенты в блюде: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_ingr_in_food
{
    public string result;
    public string ingr_id;
    public string id_food;
    public string gross;
    public string net;
    public string id_ingr;
    public string food_name;
    public string ingr_name;
}
/// <summary>
/// Класс очередь: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_queue
{
    public string result;
    public string queue_id;
    public string season;
    public string numb_men;
    public string start;
    public string end;
    public string length;
}

/// <summary>
/// Класс блюда в диетах: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_diet_in_food
{
    public string result;
    public string card_id;
    public string food_id;
    public string diet_id;
    public string food_name;
    public string card_numb;
    public string diet_numb;
}

/// <summary>
/// Класс карточки - раскладки: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_card
{
    public string result;
    public string card_id;
    public string food_id;
    public string food_name;
    public string card_numb;
    public string cost;
    public string method;
}