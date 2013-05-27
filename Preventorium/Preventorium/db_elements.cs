using System.Collections;
/// <summary>
/// Класс ингредиенты: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о ингредиентах
/// </summary>
public class class_ingridients
{
    /// <summary>
    /// Содержит признак успешной транзакции
    /// </summary>
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
    /// <summary>
    /// Содержит признак успешной транзакции
    /// </summary>
    public string result;
    public string food_id;
    public string name;
    public string calories;
    public string proteins;
    public string fats;
    public string carbo;
    public string weight;
    public string count_portc;
    public string count_cal_food;
}

/// <summary>
/// Класс диеты: Содержит переменные которым передаются значения по sql запросу,возвращает данные о диетах
/// /// </summary>
public class class_diet
{
    /// <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    /// <summary>
    /// id диеты
    /// </summary>
    public string diet_id;
    /// <summary>
    /// № диеты
    /// </summary>
    public string numbDiet;
    /// <summary>
    /// описание диеты
    /// </summary>
    public string description;
}

/// <summary>
/// Класс книги: Содержит переменные которым передаются значения по sql запросу, возвращает сведения о справочниках
/// </summary>

public class class_book
{
    /// <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    /// <summary>
    /// айди книги
    /// </summary>
    public string book_id;
    /// <summary>
    /// автор
    /// </summary>
    public string author;
    /// <summary>
    /// год выпуска 
    /// </summary>
    public string year;
    /// <summary>
    /// наименование книги
    /// </summary>
    public string name;
}

/// <summary>
/// Класс игридиенты в блюде: Содержит переменные которым передаются значения по sql запросу,возвращает сведения в карточку-раскладку: вес брутто и нетто блюда
/// </summary>
public class class_ingr_food
{
    /// <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    /// <summary>
    /// вес нетто
    /// </summary>
    public string net;
    /// <summary>
    /// вес брутто
    /// </summary>
    public string bruto;  
}

/// <summary>
/// Класс карта-ракскладка: Содержит переменные которым передаются значения по sql запросу,возвращает сведения в карточку-раскладку: цену блюда, номер карточки раскладки,  метод приготовления блюда
/// /// </summary>
public class class_cards
{   
   /// <summary>
    /// Содержит признак успешной транзакци
   /// </summary>
 public string result;
    /// <summary>
    /// id карты 
    /// </summary>
    public string id;
    /// <summary>
    /// способ приготовления блюда
    /// </summary>
    public string opis;
    /// <summary>
    /// цена блюда
    /// </summary>
    public string cost;
    /// <summary>
    /// номер карты
    /// </summary>
    public string nam_card;
}


/// <summary>
/// Класс персона: Содержит переменные которым передаются значения по sql запросу,возвращает сведения в карточку-раскладку, о работающих в профилактории
/// </summary>
public class class_person
{
    /// <summary>
    /// id должности
    /// </summary>
    public string post_id;
    /// <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    /// <summary>
    /// имя
    /// </summary>
    public string name;
    /// <summary>
    /// фамилия
    /// </summary>
    public string surname;
    /// <summary>
    /// отчество
    /// </summary>
    public string secondname;
    /// <summary>
    /// должность
    /// </summary>
    public string post;
    /// <summary>
    /// логин
    /// </summary>
    public string login;
    /// <summary>
    /// паролоь
    /// </summary>
    public string pass;  
    /// <summary>
    /// роль пользователя
    /// </summary>
    public string role;
}

/// <summary>
/// Класс ингредиенты в блюде: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о ингридиентах в блюдах
/// </summary>
public  class class_ingr_in_food
{
    // <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    /// <summary>
    /// айди ингредиента
    /// </summary>
    public string ingr_id;
    /// <summary>
    /// айди блюда
    /// </summary>
    public string id_food;
    /// <summary>
    /// вес брутто
    /// </summary>
    public string gross;
    /// <summary>
    /// вес нетто
    /// </summary>
    public string net;
/// <summary>
/// наименование блюда
/// </summary>
    public string food_name;
    /// <summary>
    /// наименование ингредиента
    /// </summary>
    public string ingr_name;
}
/// <summary>
/// Класс очередь: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о очереди
/// </summary>
public class class_queue
{  /// <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    /// <summary>
    /// id очереди
    /// </summary>
    public string queue_id;
    /// <summary>
    /// кол-во людей
    /// </summary>
    public string numb_men;
    /// <summary>
    /// дата начала
    /// </summary>
    public string start;
    /// <summary>
    /// номер очереди
    /// </summary>
    public string numb_queue;
    /// <summary>
    /// дата окончания
    /// </summary>
    public string end;
    /// <summary>
    /// кол-во дней в очереди
    /// </summary>
    public string length;
}

/// <summary>
/// Класс блюда в диетах: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о диетах в блюде
/// </summary>
public class class_diet_in_food
{    /// <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    
    public string card_id;
    public string food_id;
    public string diet_id;
    /// <summary>
    /// наименование блюда
    /// </summary>
    public string food_name;
    /// <summary>
    /// номер карты
    /// </summary>
    public string card_numb;
    /// <summary>
    /// номер диеты
    /// </summary>
    public string diet_numb;
}

/// <summary>
/// Класс карточки - раскладки: Содержит переменные которым передаются значения по sql запросу,возвращает сведения о карточке-раскладке
/// </summary>
public class class_card
{    /// <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    public string card_id;
    public string food_id;
    /// <summary>
    /// наименование блюда
    /// </summary>
    public string food_name;
    /// <summary>
    /// номер карты
    /// </summary>
    public string card_numb;
    /// <summary>
    /// номер диеты
    /// </summary>
    public string diet_numb;
    /// <summary>
    /// цена блюда
    /// </summary>
    public string cost;
    /// <summary>
    /// метод приготовления
    /// </summary>
    public string method;
}

/// <summary>
/// Класс рецептов используемых для блюд
/// </summary>
public class food_in_book
{  
    /// <summary>
    /// Содержит признак успешной и
    /// </summary>
    public string result;
    public string book_id;
    public string food_id;
    public string card_id;
    /// <summary>
    /// наименование книги
    /// </summary>
    public string book;
    /// <summary>
    /// наименование блюда
    /// </summary>
    public string food;
    /// <summary>
    /// номер карты
    /// </summary>
    public string card;
}

/// <summary>
/// класс меню создаваемый для очереди
/// </summary>
public class class_menu
{    // <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    public string menu_id;
    public string queue_id;
    /// <summary>
    /// номер очереди
    /// </summary>
    public string numb_queue;
}
/// <summary>
/// Класс меню на день: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_menu_in_day
{    // <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    public string menu_id;
    public string day_id;
    /// <summary>
    /// дата создания меню
    /// </summary>
    public string day;
}
/// <summary>
/// Класс блюда в меню: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_food_in_menu
{   
    /// <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
    public string result;
    public string menu_id;
    public string day_id;
    public string food_id;
    /// <summary>
    /// время подачи блюда
    /// </summary>
    public string serve_time;
    /// <summary>
    /// наименование блюда
    /// </summary>     
    public string food;   
}


/// <summary>
/// Класс пользователи: Содержит переменные которым передаются значения по sql запросу
/// </summary>
public class class_user
{    /// <summary>
    /// Содержит признак успешной транзакци
    /// </summary>
  public string result;
  public string password;
  public string user;
}