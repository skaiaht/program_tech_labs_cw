using System.Reflection;

namespace program_tech_labs_cw.Models;

public static class InscriptionProvider
{
    public const string DirectoryNotFound = "Папка была перемещена или удалена";
    public const string DirectoryNotSpecified = "Папка не выбрана";
    public const string DirectorySelect = "Выберите папку";
    
    public const string FileNotFound = "Файл был перемещен или удален";
    public const string FileNotSpecified = "Файл не выбран";
    public const string FileSelect = "Выберите файл";
    public const string FileReadError = "Ошибка чтения файла";
    public const string FileLoadError = "Ошибка загрузки файла";

    public const string ExtensionEmpty = "Пустое расширение файла";
    public const string ExtensionWrong = "Неправильное расширение файла";

    public const string SaveSuccess = "Успешное сохранение";
    public const string SaveError = "Ошибка сохранения";

    public const string SettingsReadError = "Ошибка чтения настроек приложения";
    public const string SettingsWriteError = "Ошибка записи настроек приложения";
    public const string SettingsKeyError = "Ключ не существует";
    public const string SettingsValueError = "Значение не существует";
    
    public const string Ok = "Ок";
    public const string Cancel = "Отмена";
    public static string AssemblyName = Assembly.GetExecutingAssembly().GetName().Name ?? string.Empty;
    public static string AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;
}