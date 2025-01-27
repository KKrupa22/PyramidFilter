.data
kernelMask dq 00002000300020001h, 00000000000000001h
kernelMask2 dq 00004000600040002h, 00000000000000002h
kernelMask3 dq 00006000900060003h, 00000000000000003h
maskRed dq 0FF0000FF0000h, 0FF0000FF0000FFh
maskGreen dq 0FF0000FF0000FF00h, 00000FF0000FF0000h
maskBlue dq 0FF0000FF0000FFh, 00000FF0000FF00h
shufMaskBlue dq 0FFFFFF0C09060300h, 0FFFFFFFFFFFFFFFFh
shufMaskGreen dq 0FFFFFF0D0A070401h, 0FFFFFFFFFFFFFFFFh
shufMaskRed dq 0FFFFFF0E0B080502h, 0FFFFFFFFFFFFFFFFh
shufFinalRed dq 0FFFFFFFFFF00FFFFh, 0FFFFFFFFFFFFFFFFh
shufFinalGreen dq 0FFFFFFFFFF0200FFh, 0FFFFFFFFFFFFFFFFh
shufFinalBlue dq 0FFFFFFFFFF020100h, 0FFFFFFFFFFFFFFFFh
maskSum dq 0000000000000FFFFh, 00000000000000000h
maskCorrect db 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
maskCorrect2 db 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255
bpp dq 3

.code
PyramidASM proc
    push rbp
    mov rbp, rsp

    mov r10, [rsp + 48] ;startY
    mov r11, [rsp + 56] ;endY
    mov rsi, rdx ;Destination
    mov rdi, rcx ;Source
    ; r8 - width
    ; r9 - height

    movdqu xmm0, xmmword ptr[kernelMask] ; Wrzucenie do 3 rejestrow XMM masek filtru
    movdqu xmm1, xmmword ptr[kernelMask2]
    movdqu xmm2, xmmword ptr[kernelMask3]

    mov rax, r8 ; Sprawdzanie czy padding istnieje: ((szerokosc * 3) % 4) != 0
    mov rbx, [bpp]
    mul rbx
    mov rbx, 4
    div rbx
    cmp rdx, 0
    je no_padding

padding: ; Jezeli z wyniku dzielenia zosta³a reszta to padding = 4 - ((szerokosc * 3) % 4) = r15
    sub rbx, rdx
    mov r15, rbx
    jmp end_padding

no_padding: ; Jezeli z wyniku dzielenia nie ma reszty, to czyszczony jest rejestr
    xor r15, r15

end_padding: ; Po zapisaniu paddingu czyszczony jest rejestr potrzebny do dzielenia
    xor rbx, rbx

skip_init: ; Inicjowanie licznika pominiêæ: r12 = szerokoœæ - 4 poniewa¿ ramka jest po 2 stronach
    mov r12, r8
    sub r12, 4

    cmp r11, r9 ; Sprawdzenie czy znajdujemy sie w ostatnim rzêdzie
    je last_row
    jmp not_last

last_row: ; Jezeli tak to w ostatnim rzedzie to pomijamy 2 rzêdy poprzednie
    sub r11, 2

not_last: ; Obliczamy wielkoœæ naszego chunka w bajtach uwzglêdniaj¹c padding, oraz miejsce w którym zacznie siê pobieranie wartoœci ze Ÿród³a
    mov rax, r11 ; Obliczanie wielkoœci chunka w bajtach
    imul rax, r15

    imul r11, r8
    imul r11, [bpp]
    add r11, rax

    xor r13, r13
    xor rax, rax

    mov rax, r15 ; Obliczanie miejsca w którym zacznie siê pêtla g³ówna
    imul rax, r10

    imul r10, r8
    imul r10, [bpp]
    add r10, rax
    add r10, 6

processChunk:
    cmp r11, r10 ; Sprawdzenie czy jesteœmy na koñcu
    js exitFunc
    inc r13

    mov r14, r13 ; Obliczanie miejsca z którego chcemy pobraæ pixele do wymno¿enia przez maske filtru: StartY - (licznik mno¿eñ - 3) * (padding + szerokoœæ * 3) - 6
    sub r14, 3
    mov rax, r15
    imul rax, r14
    imul r14, r8
    imul r14, [bpp]
    add r14, r10
    add r14, rax
    sub r14, 6

    movdqu xmm3, [rdi + r14] ; Wrzucanie 5 pixeli do 3 rejestrów XMM
    movdqu xmm4, xmm3
    movdqu xmm5, xmm3

    pand xmm3, xmmword ptr[maskRed] ; Rozdzielanie wartoœci na R, G, B
    pand xmm4, xmmword ptr[maskGreen]
    pand xmm5, xmmword ptr[maskBlue]

    pshufb xmm3, xmmword ptr[shufMaskRed] ; Przesuniêcie wartoœci w taki sposób by wartoœci znajdowa³y siê obok siebie
    pshufb xmm4, xmmword ptr[shufMaskGreen]
    pshufb xmm5, xmmword ptr[shufMaskBlue]

    pmovzxbw xmm3, xmm3 ; Rozszerzanie bajtów do s³ów, ¿eby podczas mno¿enia mog³o dojœæ do overflow bez ingerencji w inne kolory
    pmovzxbw xmm4, xmm4
    pmovzxbw xmm5, xmm5

    cmp r13, 1 ; Wybieranie odpowiedniej maski
    je firstMask
    cmp r13, 2
    je secondMask
    cmp r13, 3
    je thirdMask
    cmp r13, 4
    je secondMask
    cmp r13, 5
    je firstMask

firstMask:
    pmullw xmm3, xmm0
    pmullw xmm4, xmm0
    pmullw xmm5, xmm0
    jmp continueProcess

secondMask:
    pmullw xmm3, xmm1
    pmullw xmm4, xmm1
    pmullw xmm5, xmm1
    jmp continueProcess

thirdMask:
    pmullw xmm3, xmm2
    pmullw xmm4, xmm2
    pmullw xmm5, xmm2
    jmp continueProcess

continueProcess:
    paddw xmm6, xmm3 ; Sumowanie wartoœci tych samych kolorów w roboczych rejestrach
    paddw xmm7, xmm4
    paddw xmm8, xmm5

    cmp r13, 5 ; Sprawdzenie czy wykonaliœmy ca³a maskê filtru
    je saveToDest
    jmp processChunk

saveToDest: ; Po wykonaniu ca³ej maski filtru zapisujemy wynik do docelowego obrazu
    xor r13, r13

    phaddw xmm6, xmm6 ; Horyzontalnie dodajemy te same kolory, by z tych 25 wartoœci uzyskaæ jedn¹
    phaddw xmm6, xmm6
    phaddw xmm6, xmm6
    pand xmm6, xmmword ptr[maskSum] ; Po wykonaniu operacji horyzontalnego dodawania musimy zamaskowaæ wartoœci, których nie potrzebujemy

    phaddw xmm7, xmm7
    phaddw xmm7, xmm7
    phaddw xmm7, xmm7
    pand xmm7, xmmword ptr[maskSum]

    phaddw xmm8, xmm8
    phaddw xmm8, xmm8
    phaddw xmm8, xmm8
    pand xmm8, xmmword ptr[maskSum]

    mov rcx, 81 ; Po otrzymaniu wartoœci trzeba znormalizowaæ wyniki poprzez podzielenie ka¿dego z nich przez sumê wartoœci maski
    movq rax, xmm6
    xor rdx, rdx
    div rcx
    movq xmm9, rax
    pshufb xmm9, xmmword ptr[shufFinalRed] ; Wrzucenie wartoœci do rejestru, oraz przesuniecie jej na prawid³owe miejsce

    movq rax, xmm7
    xor rdx, rdx   
    div rcx
    movq xmm10, rax
    paddb xmm9, xmm10
    pshufb xmm9, xmmword ptr[shufFinalGreen]

    movq rax, xmm8
    xor rdx, rdx
    div rcx
    movq xmm10, rax
    paddb xmm9, xmm10

    lea rax, [maskCorrect] ; Zabezpiecznie docelowego obrazu przed nadpisywaniem go przez rozne watki
    movdqu xmm11, [rax] ; Zaladowanie do xmm11 maski
    pand xmm9, xmm11 ; Maskowanie by wyzerowac bajty, których nie zmieniamy
    movdqu xmm12, [rsi + r10] ; Wrzucenie do xmm12, zawartosci docelowej w celu zachowania zmian

    lea rax, [maskCorrect2] 
    movdqu xmm11, [rax]
    pand xmm12, xmm11
    paddb xmm9, xmm12

    movdqu [rsi + r10], xmm9 ; Zapisanie pixela do docelowego obrazu
    add r10, 3 ; Przesuniêcie siê do nastêpnego pixela
    sub r12, 1 ; Dekrementujemy licznik pominieæ o 1
    cmp r12, 0 ; Sprawdzamy czy licznik pominiêæ = 0
    je skiping

skip_complete:
    pxor xmm6, xmm6
    pxor xmm7, xmm7
    pxor xmm8, xmm8
    jmp processChunk

skiping: ; Jezeli licznik pominiec = 0, to pomijane sa 4 pixele + padding, by stworzyc ramke, poniewaz nie ma miejsca na zastosowanie filtru maski
    add r10, 12
    add r10, r15
    mov r12, r8
    sub r12, 4
    jmp skip_complete

exitFunc:
    pop rbp
    ret

PyramidASM endp
end