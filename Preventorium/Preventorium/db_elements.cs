using System.Collections;
/// <summary>
/// Класс ингредиенты: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о ингредиентах
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
/// Класс блюда: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о блюде
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
    public string count_portc;
}
/// <summary>
/// Класс диеты: Содержит переменные которым передаются значения по sql запросу,возвращает данные о диетах
/// /// </summary>
public class class_diet
{
    public string result;
    public string diet_id;
    public string numbDiet;
    public string description;
}

/// <summary>
/// Класс книги: Содержит переменные которым передаются значения по sql запросу, возвращает сведения о справочниках
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
/// Класс игридиенты в блюде: Содержит переменные которым передаются значения по sql запросу,возвращает сведения в карточку-раскладку: вес брутто и нетто блюда
/// </summary>
public class class_ingr_food
{
    public string result;
    public string net;
    public string bruto;  
}

/// <summary>
/// Класс карта-ракскладка: Содержит переменные которым передаются значения по sql запросу,возвращает сведения в карточку-раскладку: цену блюда, номер карточки раскладки,  метод приготовления блюда
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
/// Класс должность: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о должности  в карточку-раскладку 
/// </summary>
public class class_post
{
    public string id;
    public string result;
    public string position;
}


/// <summary>
/// Класс персона: Содержит переменные которым передаются значения по sql запросу,возвращает сведения в карточку-раскладку, о работающих в профилактории
/// </summary>

public class class_person
{
    public string post_id;
    public string result;
    public string name;
    public string surname;
    public string secondname;
    public string post;
    public string login;
    public string pass;
    public string id;
}

/// <summary>
/// Класс ингридиенты в блюде: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о ингридиентах в блюдах
/// </summary>
public  class class_ingr_in_food
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
/// Класс очередь: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о очереди
/// </summary>
public class class_queue
{
    public string result;
    public string queue_id;
    public string numb_men;
    public string start;
    public string numb_queue;
    public string end;
    public string length;
}

/// <summary>
/// Класс блюда в диетах: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о диетах в блюде
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
/// Класс карточки - раскладки: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о карточке-раскладке
/// </summary>
public class class_card
{
    public string result;
    public string card_id;
    public string food_id;
    public string food_name;
    public string card_numb;
    public string diet_numb;
    public string cost;
    public string method;
}

/// <summary>
/// Класс рецептов используемых для блюд
/// </summary>
public class food_in_book
{
    public string result;
    public string book_id;
    public string food_id;
    public string card_id;
    public string book;
    public string food;
    public string card;
}

/// <summary>
/// класс меню создаваемый для очереди
/// </summary>
public class class_menu
{
    public string result;
    public string menu_id;
    public string queue_id;
    public string numb_queue;
}

public class class_menu_in_day
{
    public string result;
    public string menu_id;
    public string day_id;
    public string day;
}
public class class_food_in_menu
{
    public string result;
    public string menu_id;
    public string day_id;
    public string food_id;
    public string serve_time;
    public string food;
    public string serve;
}


public class class_menu_in_food
{
    public string result;
    public string service;
    public string food_id;
}

public class class_user
{
  public string result;
  public string password;
  public string user;
}