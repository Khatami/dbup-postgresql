INSERT INTO public.coupon (productname, description, amount)
SELECT 'IPhone 10', 'Samsung Discount', 150
WHERE NOT EXISTS (SELECT * FROM public.coupon WHERE productname = 'IPhone 10');

INSERT INTO public.coupon (productname, description, amount)
SELECT 'IPhone X', 'IPhone Discount', 200
WHERE NOT EXISTS (SELECT * FROM public.coupon WHERE productname = 'IPhone X');