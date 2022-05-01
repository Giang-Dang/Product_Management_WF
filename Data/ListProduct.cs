﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Manage_Tool_WF.Data
{
    public struct ListProduct
    {
        public Product[] List;
        public int CurrentLength;

        public ListProduct(Product[] _list, int _currentLength)
        {
            List = _list;
            CurrentLength = _currentLength;
        }

        //Instance Methods
        public void Add(Product newProduct)
        {
            if(CurrentLength < Global.MAX_LIST_LENGTH)
            {
                List[CurrentLength] = newProduct;
                CurrentLength++;
            }
        }

        public int IndexOf(Product product)
        {
            for (int i = 0; i < CurrentLength; i++)
            {
                if(List[i].Equals(product))
                {
                    return i;
                }
            }
            return -1;
        }
        public bool IsContain(Product product)
        {
            if (IndexOf(product) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void RemoveAt(int removePosition)
        {
            //when element's index reach Max index
            if (removePosition == Global.MAX_LIST_LENGTH - 1)
            {
                List[removePosition] = default(Product);
                CurrentLength--;
            }
            //
            else
            {
                for (int i = removePosition; i < CurrentLength - 1; i++)
                {
                    if (i + 1 <= Global.MAX_LIST_LENGTH)
                    {
                        List[i] = List[i + 1];
                    }
                }
                List[CurrentLength - 1] = default(Product);
                CurrentLength--;
            }
        }
        public void Remove(Product removeProduct)
        {
            int removePosition = IndexOf(removeProduct);

            if (removePosition != -1)
            {
                RemoveAt(removePosition);
            }
        }
        public void RemoveAllProductInType(string type)
        {
            Product[] res = new Product[Global.MAX_LIST_LENGTH];
            int count = 0;
            for (int i = 0; i < CurrentLength; i++)
            {
                if (List[i].ProductType != type)
                {
                    res[count] = List[i];
                    count++;
                }
            }
            List = res;
            CurrentLength = count;
        }
        public void EditAt(int editingPosition, Product product)
        {
            List[editingPosition] = product;
        }

        public void EditTypeForAllProductsHaveType(string oldType, string newType)
        {
            for (int i = 0; i < CurrentLength; i++)
            {
                if (List[i].ProductType == oldType)
                {
                    List[i].ProductType = newType;
                }
            }
        }

        public Product[] FindProductsHaveID(string ID)
        {
            Product[] tempResultList = new Product[CurrentLength];
            int count = 0;
            for (int i = 0 ; i < CurrentLength; i++)
            {
                if (List[i].ProductID == ID)
                {
                    tempResultList[count] = List[i];
                    count++;
                }
            }
            Product[] res = Product.ShortenProductArray(tempResultList);
            return res;
        }

        public Product[] FindAllProductInType(string type)
        {
            Product[] tempResultList = new Product[CurrentLength];
            int count = 0;
            for (int i = 0; i < CurrentLength; i++)
            {
                if (List[i].ProductType == type)
                {
                    tempResultList[count] = List[i];
                    count++;
                }
            }
            Product[] res = Product.ShortenProductArray(tempResultList);
            return res;
        }

        
    }
}