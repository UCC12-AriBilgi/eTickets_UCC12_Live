namespace eTickets.Data.Enums
{
    // Film kategorilerini tutacak olan bir liste yapısı gibi düşünülebilir.

    public enum MovieCategory
    {
        // Normalde böyle bir liste yapısında index yapısı 0 dan başlar. Ama burada 1 den baslamasını istiyoruz. Kendisi takip eden diğer seçenekleri otomatik olarak 2,3,4... gibi numaralandırıyor

        Action = 1,
        Comedy,
        Drama,
        Documentary,
        Cartoon,
        Horror,
        Biography
    }
}
