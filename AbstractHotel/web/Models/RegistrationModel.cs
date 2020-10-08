﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите логин")]
        [StringLength(50, ErrorMessage = "Логин должен содержать от 1 до 50 символов", MinimumLength = 1)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите E-Mail")]
        [RegularExpression(@"/^[^@]+@[^@.]+\.[^@]+$/", ErrorMessage = "Вы ввели некорректный E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ФИО")]
        public string ClientFIO { get; set; }
    }
}
