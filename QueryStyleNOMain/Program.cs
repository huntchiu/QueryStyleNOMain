// See https://aka.ms/new-console-template for more information

List<ProductionData> productionDataList = new List<ProductionData>
{
    new ProductionData(){ SYS_ID = "3933AFB4-9E5C-4FCB-BC92-057D6EB35EC3", VER_NUM = 1 ,BUY_ID = "202311", SMP_NM = "大货"},
    new ProductionData(){ SYS_ID = "D9036C8B-6F55-4571-86AC-5C030658082C", VER_NUM = 1 ,BUY_ID = "202309", SMP_NM = "大货"},
    new ProductionData(){ SYS_ID = "A59A6B7F-6907-40DE-89D3-C17E9BFA967C", VER_NUM = 1 ,BUY_ID = "202310", SMP_NM = "大货"},
    new ProductionData(){ SYS_ID = "797ADF08-E003-478B-BA82-FAC835663C02", VER_NUM = 1 ,BUY_ID = "SS2302", SMP_NM = "大办"},
    new ProductionData(){ SYS_ID = "177993A3-92CC-4648-90A7-FF4D40F09DA9", VER_NUM = 1 ,BUY_ID = "SS2305", SMP_NM = "大办"},
    new ProductionData(){ SYS_ID = "177993A3-92CC-4648-90A7-FF4D40F09DA1", VER_NUM = 1 ,BUY_ID = "202375", SMP_NM = "齐码办"},
    new ProductionData(){ SYS_ID = "177993A3-92CC-4648-90A7-FF4D40F09DA2", VER_NUM = 1 ,BUY_ID = "202395", SMP_NM = "齐码办"},
};

var result = productionDataList
    .Where(data => data.SMP_NM == "大货")
    .Select(data => new
    {
        Data = data,
        BuyIdNumber = data.BUY_ID
    })
    .OrderByDescending(x => x.BuyIdNumber)
    .ThenByDescending(x => x.Data.VER_NUM)
    .FirstOrDefault();

if (result != null )
{
    Console.WriteLine($"最大的 BUY_ID 是 {result.BuyIdNumber}，版本号是 {result.Data.VER_NUM}");
}
else
{
    
    var resultForDaBan = productionDataList
        .Where(data => data.SMP_NM == "大办")
        .Select(data => new
        {
            Data = data,
            BuyIdNumber = data.BUY_ID
        })
        .OrderByDescending(x => x.BuyIdNumber)
        .ThenByDescending(x => x.Data.VER_NUM)
        .FirstOrDefault();

    if (resultForDaBan != null)
    {
        Console.WriteLine($"最大的 BUY_ID 是 {resultForDaBan.BuyIdNumber}，版本号是 {resultForDaBan.Data.VER_NUM}");
    }
    else
    {
        
        var resultForQiMaBan = productionDataList
            .Where(data => data.SMP_NM == "齐码办")
            .Select(data => new
            {
                Data = data,
                BuyIdNumber = data.BUY_ID
            })
            .OrderByDescending(x => x.BuyIdNumber)
            .ThenByDescending(x => x.Data.VER_NUM)
            .FirstOrDefault();

        if (resultForQiMaBan != null)
        {
            Console.WriteLine($"最大的 BUY_ID 是 {resultForQiMaBan.BuyIdNumber}，版本号是 {resultForQiMaBan.Data.VER_NUM}");
        }
        else
        {
            Console.WriteLine("找不到符合条件的记录。");

        }
        
    }
    
}


public class ProductionData
{
    public string? SYS_ID { get; set; }
    public string? BUY_ID { get; set; }
    public int? VER_NUM { get; set; }
    public string? SMP_NM { get; set; }
   
};


/*
计算款号相关的工序总表
SMP_NM   == 大货 
BUY_ID  => 字串转成数字
拿到其中最大的一个
如果BUY_ID 相同，则比较版本的数字
拿到其中最大的一个
如果都不符合返回null
SMP_NM   == 大办 和上面的比较逻辑一样
SMP_NM   == 齐码办 和上面的比较逻辑一样
*/