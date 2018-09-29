#!/usr/bin/lua

record = {} -- Contains chain lenght of computed numbers
            -- To use in case of getting repeated number in calculating chain
max = 0
maxlen = 1
function Collatz(n)
 local len = 1
 local orig = n
 while n ~= 1 do
	if record[n] then
	 len = len + record[n] - 1
	 break
	end
	-- print(n .. " -> ")
	n = (n%2 ~= 0 and 3*n + 1) or n/2
	len = len + 1
 end
 record[orig] = len
 if len > maxlen then maxlen = len; max = orig end
 return len
end

for i=1,999999 do
	Collatz(i)
end

print("max: " .. max .. "\tlen: " .. maxlen)
