using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Shared.ViewModels
{
    public class AddProductViewModel
    {
        [JsonPropertyName("Name")]
        [DisplayName("Ürün")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MinLength(5, ErrorMessage = "{0} alanına uzunluğu {1} karakterden küçük değer girilemez.")]
        [MaxLength(100, ErrorMessage = "{0} alanına uzunluğu {1} karakterden büyük değer girilemez.")]
        public string Name { get; set; }


        [JsonPropertyName("Properties")]
        [DisplayName("ürün özellikleri")]
        public string Properties { get; set; }


        [JsonPropertyName("Price")]
        [DisplayName("ürün Fiyatı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public decimal? Price { get; set; }


        [JsonPropertyName("ImageUrl")]
        [DisplayName("Resim")]
        public string ImageUrl { get; set; } = "";


        [JsonPropertyName("Url")]
        public string Url { get; set; }


        [JsonPropertyName("IsActive")]
        [DisplayName("Aktif ürün")]
        public bool IsActive { get; set; }


        [JsonPropertyName("IsHome")]
        [DisplayName("Ana Sayfa ürünü")]
        public bool IsHome { get; set; }


        [JsonPropertyName("CategoryIds")]
        public List<int> CategoryIds { get; set; } = new List<int>(); //Yeni oluşan sayfada categoryid null gitmesin diye yazdık.


        [DisplayName("Kategoriler")]
        public List<CategoryViewModel> Categories { get; set; }
    }
}
