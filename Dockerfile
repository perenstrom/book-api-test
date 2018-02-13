FROM debian:jessie
ADD BookApi/publish .
RUN apt-get update && apt-get install libunwind8 libicu52 libssl1.0.0
EXPOSE 5000
CMD ./BookApi
