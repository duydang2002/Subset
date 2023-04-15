
namespace Subset
{
    internal class Subset
    {
        static List<int> list = new List<int>();
        static Boolean Check(int[] arr, int sum,int n,int curSum)
        {
            
            for (int i = arr.Length - n-1; i >= 0;i--)
            {   
                // Neu ma curSum ma + them voi arr[i] == sum thi tra ve tru
                if (curSum== sum - arr[i]) {
                    list.Add(arr[i]);    
                    return true;
                }
                // Neu ma curSum + voi arr[i] ma van < sum thi + vao curSum
                // va goi de quy den so tiep theo
                if (curSum < sum - arr[i])
                {
                    curSum += arr[i];
                    list.Add(arr[i]);
                    if (Check(arr, sum, n + 1,curSum)) return true;
                // Duong di nay khong cho ve ket qua true nen ta se tru curSum di va di tiep
                    curSum -= arr[i];
                    list.RemoveAt(list.Count-1);                
                }
                // Neu curSum + arr[i] > sum thi xet xem neu o vi tri cuoi roi thi se tra 
                // ve false con chua thi di tiep
                if (curSum > sum - arr[i]) { 
                    if (i!=0)
                    continue;
                    return false;
                }
            }
            return false;
        }
        static void Main(String[] args)
        {
            int[] arr = new int[] { 2, 1, 2, 4, 3, 5, 2, 6 };
            // Sap xep mang tu be den lon 
            Array.Sort(arr);
           
            Console.WriteLine(Check(arr,14,0,0));
            foreach(var i in list)
            {
                Console.Write(i);
            }
            

        }
    }
}