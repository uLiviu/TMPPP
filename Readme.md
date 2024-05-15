Factory Method (Pages/Admin/Products/Factory Method) - Creez device-uri electronice, în dependență de ProductType, adică de ce va alege utilizatorul. Sunt doar 3 la număr, DigialClock, PortableRadio, PocketCalculator.

Builder (Pages/Admin/Products/Builder) - Creez device-uri electronice, doar că deja pas cu pas, fluent.

Protoype (Pages/Admin/Products/Prototype) - Am opțiunea de a clona un produse deja creat, dacă voi avea 2 produse care se diferențiează prin 2 câmpuri.

Decorator (Pages/Admin/Products/Decorator) - Suprascriu proprietatea de preț a produslui, modificând prețul în funcție de garanție

Observer (Pages/Admin/Products/Observer) - Am opțiunea de a adăuga produse la favorite. Când adminul editeaza acele produse sau le șterge, atunci fiecare utilizator, primește o notificare despre asta.

Facade (Pages/Admin/Orders/Facade) - Am opțiunea de a plasa o comandă. Prin facade, ascund că verific mai întâi dacă cantitatea solicitată e mai mică de cânt cantitatea din stoc, ulterior plasez comanda, iar la final actualizez stocul

Chain Of Responsability (Pages/Admin/Orders/Chain of Responsability) - Ceea ce fac în Facade, gestionez prin Chain of Responsability.

Proxy (Pages/Admin/Reviews/Proxy) - Utilizatorii pot adăuga recenzii la produse și au opțiunea de a le edita. Nimeni decât acel utilizator nu poate edita acea recenzie, nici chiar Adminul.

Strategy (Pages/Admin/Reviews/Strategy) - Folosec la sortarea recenziilor, în dependență de Username, Rating sau Numele Produsului.