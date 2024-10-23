using Task2.Entities;
using Task2.Impelemntations;

var createPermission = new Permission("create");
var readPermission = new Permission("read");
var updatePermission = new Permission("update");
var deletePermission = new Permission("delete");

// Создание ролей с соответствующими разрешениями
var adminRole = new Role("Admin", new HashSet<Permission> { createPermission, readPermission, updatePermission, deletePermission });
var userRole = new Role("User", new HashSet<Permission> { readPermission, updatePermission });
var guestRole = new Role("Guest", new HashSet<Permission> { readPermission });

// Создание пользователей
var admin = new User("Admin", adminRole);
var user = new User("User", userRole);
var guest = new User("Guest", guestRole);

// Проверка разрешений
var permissionChecker = new PermissionChecker();

// CRUD операции
var crudOperation = new CrudOperation(permissionChecker);

// Выполнение операций
crudOperation.PerformOperation(admin, createPermission); // Успех
crudOperation.PerformOperation(user, createPermission);  // Ошибка
crudOperation.PerformOperation(guest, readPermission);   // Успех
crudOperation.PerformOperation(guest, deletePermission); // Ошибка