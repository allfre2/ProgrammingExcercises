#!/usr/bin/lua

 function cicle (n)

  -- This function returns the length of the cicle of the unit fraction 1/n
  -- if the fraction is a recurring cicle and returns the cicle in string format?!
  str = "0."
  num = 1; denum = n
  rem = denum 
  table = {}
  table[1] = 0
  startpos = 0
  endpos = 0
  while rem ~= 0 do
     num = num*10
   if num < denum then 

   endpos = endpos + 1
   str = str .. "0"
   else 
    endpos = endpos + 1 
   rem = num - math.floor(num/denum)*denum      --> :( I have lua 5.0 
     str = str ..  tostring(math.floor(num / denum))

   if table[rem] ~= nil then
    startpos = table[rem]
    
    break
   else
    table[rem] = endpos
    num = rem
   end
  end
  end   
 if rem ~= 0 then
  str = string.sub(str,0,2+startpos) .. "(" .. string.sub(str,3+startpos) .. ")"
  return str ,endpos - startpos
 else 
  return str,0
 end

 end


 -- Main 
    longest,len = "",0
    for i=1,10000,2 do
    result,length = cicle(i)
    if(length > len) then len = length; number = i; longest = result end 

    end
 print ("\n\n\n Longest: " .. number ..  "\n length: " .. len .. " \n\n Result: \n" .. longest .. "\n\n") 
