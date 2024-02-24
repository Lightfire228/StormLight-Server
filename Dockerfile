FROM archlinux:latest

RUN pacman -S --noconfirm \
    aspnet-runtime        \
    dotnet-runtime        \
    dotnet-sdk            \



