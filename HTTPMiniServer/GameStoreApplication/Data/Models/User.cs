namespace HTTPMiniServer.GameStoreApplication.Data.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;

   public class User
    {

       public int Id { get; set; }

      [Required]
      [MinLength(2)]
      [MaxLength(30)]
       public string Name { get; set; }

      [Required]
      [MaxLength(30)]
       public string Password { get; set; }

      [Required]
      [MinLength(6)]
      [MaxLength(50)]
       public string Email { get; set; }

       public bool IsAdmin { get; set; }


       public List<UserGame> Games { get; set; }
    }
}
