<template>
  <div class="d-flex justify-content-between">
    <div class="col-6">
      <h1 class="text-danger">NASIL OYNANIR?</h1>
    <p>
      TBLFANTSY Lig, Klasik fantezi basketbol prensibine göre işleyen TBLFANTSY
      uygulamasında kullanıcılar, verilen bütçeyle Türkiye Basketbol Ligi
      basketbolcularından kadro kurmakta ve kadrolarına seçtikleri
      basketbolcuların Süper Lig'de o haftaki gerçek maç istatistikleriyle
      TBLFANTSY Lig puanlama sistemine göre puan toplamaktadır. Kullanıcılar,
      topladıkları puanlarla birbirleriyle sezon boyunca rekabet etmektedir
    </p>
    <div>
      <h3 class="text-danger">Nasıl Üye olunur?</h3>
      <p>
        Uygulamaya Facebook hesabı ya da mail adresiyle üye olunabilir. Üyelik
        aşamasında belirlenen TAKIM ADI aynı zamanda uygulamadaki KULLANICI ADI
        olacaktır.
        <br>
        Takım adı oluştururken aşağıdaki notlar dikkate alınmalıdır.
        <ul>
          <li>Takım adı a-z, A-Z, 1-9,-,_,. ve boşluk karakterlerinden oluşabilir.</li>
          <li>Sadece rakamlardan oluşamaz.</li>
          <li>2 karakterden daha kısa, 20 karakterden daha uzun olamaz.</li>
        </ul>
      </p>
      <h3 class="text-danger">KADRO NASIL KURULUR?</h3>
      <p>
        Uygulamanın ana sayfasında yer alan takım ismini girdikten sonra kadro kurmak için gerekli sayfaya yönlendirilirsiniz.
        <br>
        Kadro kurarken aşağıdaki adımlar takip edilebilir:
        <ul>
          <li>10 oyuncu kadronuza eklemelisiniz.</li>
          <li>Bütçenizi aşamazsınız seçiminizi ona göre yapın.</li>
          <li>Kadroyu kaydettikten sonra takım değişikliği bir sonraki hafta olur.</li>
        </ul>
      </p>
    </div>
    </div>
    <div class="col-6">
      <h3 class="text-danger">
        TAKIM İSMİNİZİ GİRİN
      </h3>
      <tbl-text
        title="Team Name"
        placeholder="Type your team name"
        v-model="model.name"
        width="%50"
      />
      <button @click="save" class="btn btn-primary">
        <icon icon="plus" /> Save
      </button>
    </div>
  </div>
</template>

<script>
import service from "../../services/content";
import router from "@/router";
export default {
  data() {
    return {
      model: {
        name: ""
      }
    };
  },
  methods: {
    async save() {
      if (this.$route.params.id) {
        this.model.id = this.$route.params.id;
      }
      let result = await service.save(this.model);
      if (result.success ) {
        router.push({
          name: "teamdesign"
        });
      }
    }
  }
};
</script>
