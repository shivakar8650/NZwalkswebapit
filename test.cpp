

// Online C++ compiler to run C++ program online
#include <iostream>

#include <bits/stdc++.h>
using namespace std;

int sortArr(vector<int> & arr)
{
    sort(arr.begin(),arr.end());
    
    
    return arr[arr.size()-1];
}

void getelement(int arr[], int n)
{
    if (n==1 || n==0)
    {
      cout<<"first :"<<-1<<", second :"<<-1 <<endl;
    }
    else{
        
    sort(arr , arr+n);
    cout<<"first :"<<arr[1]<<", second :"<<arr[n-2] <<endl;
    }
}

bool isSorted(int arr[],int n)
{
    for(int i=0 ;i<n ;i++)
    {
        for(int j=1; j<n; j++)
        {
            if(arr[i]> arr[j])
            return false;
        }
    }
    return true;
}

void uniquesortedArr(int arr[], int n)
{
    sort(arr,arr+n);
    vector<int> sortedArr;
    
    //0-10
    for(int i=0;i<n;i++)
    {
        if(arr[i]==arr[i+1] && i!=n-1 )
        {
       cout<<"continue"<<endl;     
        continue;
        }
        else if(arr[i] !=arr[i+1])
        {
            sortedArr.push_back(arr[i]);
            cout<<" sortedArr.push_back(arr[i])"<<arr[i]<<endl;
        }
        else if(i==n-1 && arr[i] !=arr[i+1])
        {
             sortedArr.push_back(arr[i+1]);
        }
         else if(i==n-1 && arr[i] ==arr[i+1])
        {
           sortedArr.push_back(arr[i]); 
        }
         
    }
     cout<< "size:"<<sortedArr.size()<<endl;
    for(int k =0;k<n;k++)
    {
        
        if(k <sortedArr.size())
        cout<< sortedArr[k];
        else
        cout<<"_ ";
        
    }
    
    
}

int main() {
    // Write C++ code here
    //   int arr[] = {2,4,6,7,8,9};
    // // int arr[] = {0};
    //  int n = sizeof(arr)/sizeof(arr[0]);
     
  
    //  vector<int> arr1 = {2, 5, 1, 3, 0};
    //  vector<int> arr2 = {5,10,4,8,0};
     
     
    //  int result1  =  sortArr(arr1);
    //  int result2  = sortArr(arr2);
    //  cout<< "first element :"<<result1<<"\n";
    //  cout<<"second element :"<<result2<<"\n";
    
       //getelement(arr,n);
    //  bool result  = isSorted(arr,n);
    //  if(result) cout<< "true";
    //  else cout<< "false";
  
     
    //  cout << "Try programiz.pro";
    
    //int arr[]={1,1,2,2,2,3,3};
    
    int arr[] ={0,0,1,1,1,2,2,3,3,4,4};
    int n = sizeof(arr)/sizeof(arr[0]);
    
    
    uniquesortedArr(arr,n);
    
    
    //Output: [1,2,3,_,_,_,_]

    return 0;
}